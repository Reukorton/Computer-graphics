using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.DataFormats;

namespace LR1T2
{
    /// <summary>
    /// Форма лабораторной работы №3.
    /// Реализует построение двумерных фигур, аффинные преобразования,
    /// настройку цвета и стиля линии, а также переход к индивидуальному заданию.
    /// </summary>
    public partial class Form4 : Form

    {
        private System.Windows.Forms.Timer? spaceTimer;
        private bool spaceAnimationStarted = false;

        private double shipAngle1 = 0;
        private double shipAngle2 = Math.PI;

        private double shipSpeed1 = 0.045;
        private double shipSpeed2 = -0.028;

        private int spaceCenterX;
        private int spaceCenterY;
        private int orbitRadius;

        private Color spaceBackColor = Color.White;
        private Color orbitColor = Color.LightGray;
        private Color earthBorderColor = Color.DarkBlue;
        private Color earthFillColor = Color.LightBlue;
        private Color ship1Color = Color.Red;
        private Color ship2Color = Color.Green;
        // Матрицы координат для двух треугольников (3 вершины + 1 для однородных координат)
        private double[,] tri1 = new double[3, 3];
        private double[,] tri2 = new double[3, 3];

        // Параметры 1 треугольника
        private double angle1 = 0;
        private double speed1 = 5;      // Начальная скорость вращения (градусы)
        private double scale1 = 2.0;    // Начальный масштаб (большой)
        private double scaleStep1 = -0.02; // Шаг изменения масштаба (уменьшение)

        // Параметры 2 треугольника
        private double angle2 = 0;
        private double speed2 = -3;     // Начальная скорость (в обратную сторону)
        private double scale2 = 0.5;    // Начальный масштаб (маленький)
        private double scaleStep2 = 0.02; // Шаг изменения масштаба (увеличение)

        // Таймер для задания
        private System.Windows.Forms.Timer? taskTimer;
        #region Глобальные переменные

        /// <summary>
        /// Матрица тела, содержащая координаты вершин фигуры в однородных координатах.
        /// </summary>
        int[,] kv = new int[5, 3];

        /// <summary>
        /// Номер текущей выбранной фигуры.
        /// </summary>
        int currentFigure = 3;

        /// <summary>
        /// Матрица координатных осей.
        /// </summary>
        int[,] osi = new int[4, 3];

        /// <summary>
        /// Матрица преобразования сдвига.
        /// </summary>
        int[,] matr_sdv = new int[3, 3];

        /// <summary>
        /// Элементы матрицы сдвига.
        /// Используются для перемещения фигуры по экрану.
        /// </summary>
        int k, l;

        /// <summary>
        /// Переменная для запуска и остановки непрерывного преобразования.
        /// </summary>
        bool f = true;

        /// <summary>
        /// Текущий угол поворота фигуры.
        /// </summary>
        double angle = 0;

        /// <summary>
        /// Текущий коэффициент масштабирования фигуры.
        /// </summary>
        double scale = 1;

        /// <summary>
        /// Коэффициент отражения по оси X.
        /// </summary>
        int reflectX = 1;

        /// <summary>
        /// Коэффициент отражения по оси Y.
        /// </summary>
        int reflectY = 1;

        /// <summary>
        /// Режим непрерывного преобразования:
        /// 1 - смещение,
        /// 2 - поворот,
        /// 3 - увеличение,
        /// 4 - уменьшение.
        /// </summary>
        int animationMode = 1;

        /// <summary>
        /// Текущий цвет линии фигуры.
        /// </summary>
        Color currentLineColor = Color.Blue;

        /// <summary>
        /// Признак использования толстой линии.
        /// </summary>
        bool thickLine = false;

        /// <summary>
        /// Признак использования пунктирной линии.
        /// </summary>
        bool dashedLine = false;

        /// <summary>
        /// Толщина линии.
        /// </summary>
        int lineWidth = 3;

        /// <summary>
        /// Шаг пунктира.
        /// </summary>
        int dashStep = 5;

        #endregion

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public Form4()
        {
            InitializeComponent();

            InitSpaceScene();
        }

        /// <summary>
        /// Обработчик загрузки формы.
        /// Задает начальное положение фигуры и начальные параметры настройки линии.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Form4_Load(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            comboBoxLineType.Items.Add("Сплошная");
            comboBoxLineType.Items.Add("Пунктирная");
            comboBoxLineType.SelectedIndex = 0;

            numericUpDownDashStep.Minimum = 2;
            numericUpDownDashStep.Maximum = 20;
            numericUpDownDashStep.Value = 5;
            numericUpDownDashStep.Enabled = false;

            numericUpDownLineWidth.Minimum = 1;
            numericUpDownLineWidth.Maximum = 10;
            numericUpDownLineWidth.Value = 3;
            numericUpDownLineWidth.Enabled = false;
        }

        /// <summary>
        /// Создает перо для рисования фигуры с учетом выбранных параметров:
        /// цвета, толщины, типа линии и шага пунктира.
        /// </summary>
        /// <returns>Перо для рисования фигуры.</returns>
        private Pen CreateFigurePen()
        {
            int width = 1;

            if (thickLine == true)
            {
                width = lineWidth;
            }

            Pen myPen = new Pen(currentLineColor, width);

            if (dashedLine == true)
            {
                myPen.DashStyle = DashStyle.Custom;
                myPen.DashPattern = new float[] { dashStep, dashStep };
            }
            else
            {
                myPen.DashStyle = DashStyle.Solid;
            }

            return myPen;
        }

        #region Инициализация фигур и матриц

        /// <summary>
        /// Инициализирует матрицу тела для текущей выбранной фигуры.
        /// Координаты задаются в однородных координатах.
        /// </summary>
        private void Init_figure()
        {
            if (currentFigure == 3)
            {
                kv[0, 0] = -65; kv[0, 1] = -100; kv[0, 2] = 1;
                kv[1, 0] = 65; kv[1, 1] = -100; kv[1, 2] = 1;
                kv[2, 0] = -65; kv[2, 1] = 110; kv[2, 2] = 1;
                kv[3, 0] = 95; kv[3, 1] = 80; kv[3, 2] = 1;
            }

            if (currentFigure == 4)
            {
                kv[0, 0] = -70; kv[0, 1] = -100; kv[0, 2] = 1;
                kv[1, 0] = 80; kv[1, 1] = -70; kv[1, 2] = 1;
                kv[2, 0] = 10; kv[2, 1] = 0; kv[2, 2] = 1;
                kv[3, 0] = 80; kv[3, 1] = 70; kv[3, 2] = 1;
                kv[4, 0] = -70; kv[4, 1] = 100; kv[4, 2] = 1;
            }

            if (currentFigure == 11)
            {
                kv[0, 0] = 0; kv[0, 1] = -90; kv[0, 2] = 1;
                kv[1, 0] = 90; kv[1, 1] = 0; kv[1, 2] = 1;
                kv[2, 0] = 0; kv[2, 1] = 90; kv[2, 2] = 1;
                kv[3, 0] = -90; kv[3, 1] = 0; kv[3, 2] = 1;
                kv[4, 0] = 0; kv[4, 1] = 0; kv[4, 2] = 1;
            }

            if (currentFigure == 13)
            {
                kv[0, 0] = -80; kv[0, 1] = -90; kv[0, 2] = 1;
                kv[1, 0] = -80; kv[1, 1] = 70; kv[1, 2] = 1;
                kv[2, 0] = 40; kv[2, 1] = 100; kv[2, 2] = 1;
                kv[3, 0] = 130; kv[3, 1] = 45; kv[3, 2] = 1;
                kv[4, 0] = 0; kv[4, 1] = 0; kv[4, 2] = 1;
            }
        }

        /// <summary>
        /// Инициализирует матрицу сдвига.
        /// </summary>
        /// <param name="k1">Сдвиг по оси X.</param>
        /// <param name="l1">Сдвиг по оси Y.</param>
        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        /// <summary>
        /// Инициализирует матрицу координатных осей.
        /// </summary>
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }

        /// <summary>
        /// Выполняет умножение двух целочисленных матриц.
        /// </summary>
        /// <param name="a">Первая матрица.</param>
        /// <param name="b">Вторая матрица.</param>
        /// <returns>Результат умножения матриц.</returns>
        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int[,] r = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;

                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }

            return r;
        }

        /// <summary>
        /// Переводит целочисленную матрицу в матрицу типа double.
        /// </summary>
        /// <param name="a">Исходная целочисленная матрица.</param>
        /// <returns>Матрица типа double.</returns>
        private double[,] IntToDouble(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            double[,] r = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = a[i, j];
                }
            }

            return r;
        }

        /// <summary>
        /// Выполняет умножение двух матриц типа double.
        /// </summary>
        /// <param name="a">Первая матрица.</param>
        /// <param name="b">Вторая матрица.</param>
        /// <returns>Результат умножения матриц.</returns>
        private double[,] Multiply_matr_double(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = b.GetLength(1);
            int p = a.GetLength(1);

            double[,] r = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;

                    for (int ii = 0; ii < p; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }

            return r;
        }

        /// <summary>
        /// Создает матрицу сдвига типа double.
        /// </summary>
        /// <param name="k1">Сдвиг по оси X.</param>
        /// <param name="l1">Сдвиг по оси Y.</param>
        /// <returns>Матрица сдвига.</returns>
        private double[,] Init_matr_sdv_double(double k1, double l1)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = 1; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = 1; m[1, 2] = 0;
            m[2, 0] = k1; m[2, 1] = l1; m[2, 2] = 1;

            return m;
        }

        /// <summary>
        /// Создает матрицу масштабирования.
        /// </summary>
        /// <param name="s">Коэффициент масштабирования.</param>
        /// <returns>Матрица масштабирования.</returns>
        private double[,] Init_matr_scale(double s)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = s; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = s; m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        /// <summary>
        /// Создает матрицу поворота.
        /// </summary>
        /// <param name="angle">Угол поворота в градусах.</param>
        /// <returns>Матрица поворота.</returns>
        private double[,] Init_matr_rotate(double angle)
        {
            double[,] m = new double[3, 3];

            double a = angle * Math.PI / 180;

            m[0, 0] = Math.Cos(a); m[0, 1] = Math.Sin(a); m[0, 2] = 0;
            m[1, 0] = -Math.Sin(a); m[1, 1] = Math.Cos(a); m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        /// <summary>
        /// Создает матрицу отражения.
        /// </summary>
        /// <param name="rx">Коэффициент отражения по оси X.</param>
        /// <param name="ry">Коэффициент отражения по оси Y.</param>
        /// <returns>Матрица отражения.</returns>
        private double[,] Init_matr_reflect(int rx, int ry)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = rx; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = ry; m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        #endregion

        #region Рисование

        /// <summary>
        /// Рисует отрезок между двумя точками матрицы координат типа double.
        /// </summary>
        /// <param name="g">Поверхность рисования.</param>
        /// <param name="myPen">Перо для рисования.</param>
        /// <param name="a">Матрица координат.</param>
        /// <param name="p1">Индекс первой точки.</param>
        /// <param name="p2">Индекс второй точки.</param>
        private void DrawLineDouble(Graphics g, Pen myPen, double[,] a, int p1, int p2)
        {
            g.DrawLine(
                myPen,
                Convert.ToInt32(a[p1, 0]),
                Convert.ToInt32(a[p1, 1]),
                Convert.ToInt32(a[p2, 0]),
                Convert.ToInt32(a[p2, 1])
            );
        }

        /// <summary>
        /// Очищает поле рисования и выводит текущую фигуру
        /// с учетом выбранных преобразований.
        /// </summary>
        private void Draw_Kv()
        {
            ImageClear();

            Init_figure();

            double[,] kv1 = IntToDouble(kv);

            kv1 = Multiply_matr_double(kv1, Init_matr_scale(scale));
            kv1 = Multiply_matr_double(kv1, Init_matr_rotate(angle));
            kv1 = Multiply_matr_double(kv1, Init_matr_reflect(reflectX, reflectY));
            kv1 = Multiply_matr_double(kv1, Init_matr_sdv_double(k, l));

            Pen myPen = CreateFigurePen();

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            if (currentFigure == 3)
            {
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 0, 3);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
            }

            if (currentFigure == 4)
            {
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 4);
                DrawLineDouble(g, myPen, kv1, 4, 0);
            }

            if (currentFigure == 11)
            {
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 0);
            }

            if (currentFigure == 13)
            {
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 0);
            }

            g.Dispose();
            myPen.Dispose();
        }

        /// <summary>
        /// Очищает поле рисования.
        /// </summary>
        private void ImageClear()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(pictureBox1.BackColor);
            g.Dispose();
        }

        /// <summary>
        /// Выводит координатные оси в центре pictureBox.
        /// </summary>
        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(pictureBox1.Width / 2, pictureBox1.Height / 2);

            int[,] osi1 = Multiply_matr(osi, matr_sdv);

            Pen myPen = new Pen(Color.Red, 1);

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);
            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        #endregion

        #region Основные кнопки

        /// <summary>
        /// Обработчик кнопки вывода осей.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Draw_axes_Button_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Draw_osi();
        }

        /// <summary>
        /// Обработчик кнопки очистки поля рисования.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Сlear_Click(object sender, EventArgs e)
        {
            // Останавливаем таймер, чтобы треугольники перестали перерисовываться
            taskTimer?.Stop();

            // Вызываем вашу функцию очистки
            ImageClear();

            // Убираем изображение из pictureBox, чтобы экран стал пустым
            pictureBox1.Image = null;
        }

        /// <summary>
        /// Запускает или останавливает непрерывное преобразование фигуры.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Start_Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;

            Start_Button.Text = "Стоп";

            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                Start_Button.Text = "Старт";
            }

            f = !f;
        }

        #endregion

        #region Сдвиг
        /// <summary>
        /// Выполняет дискретный сдвиг фигуры вправо.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Shift_Right_Button_Click(object sender, EventArgs e)
        {
            k += 5;
            Draw_Kv();
        }

        /// <summary>
        /// Выполняет дискретный сдвиг фигуры влево.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Shift_Left_Button_Click(object sender, EventArgs e)
        {
            k -= 5;
            Draw_Kv();
        }

        /// <summary>
        /// Выполняет дискретный сдвиг фигуры вниз.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Shift_Down_Button_Click(object sender, EventArgs e)
        {
            l += 5;
            Draw_Kv();
        }

        /// <summary>
        /// Выполняет дискретный сдвиг фигуры вверх.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Shift_Up_Button_Click(object sender, EventArgs e)
        {
            l -= 5;
            Draw_Kv();
        }

        #endregion

        /// <summary>
        /// Выбирает фигуру, помещает ее в центр поля рисования
        /// и сбрасывает основные преобразования.
        /// </summary>
        /// <param name="figureNumber">Номер выбранной фигуры.</param>
        private void SelectFigure(int figureNumber)
        {
            currentFigure = figureNumber;

            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            angle = 0;
            scale = 1;
            reflectX = 1;
            reflectY = 1;

            Draw_Kv();
        }

        #region Выбор фигур

        /// <summary>
        /// Выбирает фигуру варианта 3.
        /// </summary>
        private void Variant3_Button_Click(object sender, EventArgs e)
        {
            SelectFigure(3);
        }

        /// <summary>
        /// Выбирает фигуру варианта 4.
        /// </summary>
        private void Variant4_Button_Click(object sender, EventArgs e)
        {
            SelectFigure(4);
        }

        /// <summary>
        /// Выбирает фигуру варианта 11.
        /// </summary>
        private void Variant11_Button_Click(object sender, EventArgs e)
        {
            SelectFigure(11);
        }

        /// <summary>
        /// Выбирает фигуру варианта 13.
        /// </summary>
        private void Variant13_Button_Click(object sender, EventArgs e)
        {
            SelectFigure(13);
        }

        #endregion

        #region Преобразования

        /// <summary>
        /// Выполняет отражение фигуры относительно оси OX.
        /// </summary>
        private void Reflect_OX_Button_Click(object sender, EventArgs e)
        {
            reflectY = -reflectY;
            Draw_Kv();
        }

        /// <summary>
        /// Выполняет отражение фигуры относительно оси OY.
        /// </summary>
        private void Reflect_OY_Button_Click(object sender, EventArgs e)
        {
            reflectX = -reflectX;
            Draw_Kv();
        }

        /// <summary>
        /// Увеличивает масштаб фигуры.
        /// </summary>
        private void Scale_Up_Button_Click(object sender, EventArgs e)
        {
            scale *= 1.1;
            Draw_Kv();
        }

        /// <summary>
        /// Уменьшает масштаб фигуры.
        /// </summary>
        private void Scale_Down_Button_Click(object sender, EventArgs e)
        {
            scale *= 0.9;
            Draw_Kv();
        }

        /// <summary>
        /// Поворачивает фигуру вправо.
        /// </summary>
        private void Rotate_Right_Button_Click(object sender, EventArgs e)
        {
            angle += 10;
            Draw_Kv();
        }

        /// <summary>
        /// Поворачивает фигуру влево.
        /// </summary>
        private void Rotate_Left_Button_Click(object sender, EventArgs e)
        {
            angle -= 10;
            Draw_Kv();
        }

        #endregion

        #region Непрерывные преобразования

        /// <summary>
        /// Обработчик таймера.
        /// Выполняет выбранное непрерывное преобразование фигуры.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (animationMode == 1)
            {
                k++;
            }

            if (animationMode == 2)
            {
                angle += 5;
            }

            if (animationMode == 3)
            {
                scale *= 1.02;
            }

            if (animationMode == 4)
            {
                scale *= 0.98;
            }

            Draw_Kv();
            Thread.Sleep(100);
        }

        /// <summary>
        /// Выбирает режим непрерывного сдвига.
        /// </summary>
        private void Continuous_Shift_Button_Click(object sender, EventArgs e)
        {
            animationMode = 1;
        }

        /// <summary>
        /// Выбирает режим непрерывного поворота.
        /// </summary>
        private void Continuous_Rotate_Button_Click(object sender, EventArgs e)
        {
            animationMode = 2;
        }

        /// <summary>
        /// Выбирает режим непрерывного увеличения.
        /// </summary>
        private void Continuous_Scale_Up_Button_Click(object sender, EventArgs e)
        {
            animationMode = 3;
        }

        /// <summary>
        /// Выбирает режим непрерывного уменьшения.
        /// </summary>
        private void Continuous_Scale_Down_Button_Click(object sender, EventArgs e)
        {
            animationMode = 4;
        }

        #endregion

        #region Настройка линии
        /// <summary>
        /// Обработчик выбора цвета линии фигуры.
        /// </summary>
        private void LineColor_Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentLineColor = colorDialog1.Color;
                Draw_Kv();
            }
        }

        /// <summary>
        /// Обработчик выбора толстой линии.
        /// </summary>
        private void ThickLine_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            thickLine = ThickLine_CheckBox.Checked;
            numericUpDownLineWidth.Enabled = thickLine;

            Draw_Kv();
        }

        /// <summary>
        /// Обработчик изменения толщины линии.
        /// </summary>
        private void numericUpDownLineWidth_ValueChanged(object sender, EventArgs e)
        {
            lineWidth = Convert.ToInt32(numericUpDownLineWidth.Value);
            Draw_Kv();
        }

        /// <summary>
        /// Обработчик выбора типа линии.
        /// </summary>
        private void comboBoxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLineType.SelectedIndex == 0)
            {
                dashedLine = false;
                numericUpDownDashStep.Enabled = false;
            }

            if (comboBoxLineType.SelectedIndex == 1)
            {
                dashedLine = true;
                numericUpDownDashStep.Enabled = true;
            }

            Draw_Kv();
        }

        /// <summary>
        /// Обработчик изменения шага пунктира.
        /// </summary>
        private void numericUpDownDashStep_ValueChanged(object sender, EventArgs e)
        {
            dashStep = Convert.ToInt32(numericUpDownDashStep.Value);
            Draw_Kv();
        }

        #endregion

        /// <summary>
        /// Открывает форму индивидуального задания с вращением
        /// правильного треугольника и пятиугольника.
        /// </summary>
        private void Task3_Click(object sender, EventArgs e)
        {
            using (Form5 form5 = new Form5())
            {
                this.Hide();
                form5.ShowDialog();
                this.Show();
            }
        }
        private void InitSpaceScene()
        {
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0)
                return;

            spaceCenterX = pictureBox1.Width / 2;
            spaceCenterY = pictureBox1.Height / 2;
            orbitRadius = Math.Min(pictureBox1.Width, pictureBox1.Height) / 3;

            spaceTimer = new System.Windows.Forms.Timer();
            spaceTimer.Interval = 40;
            spaceTimer.Tick += SpaceTimer_Tick;

            DrawSpaceScene();
        }

        private void StartStopSpaceAnimation()
        {
            if (spaceTimer == null)
                InitSpaceScene();

            if (spaceTimer == null)
                return;

            if (spaceAnimationStarted == false)
            {
                spaceTimer.Start();
                spaceAnimationStarted = true;

                // Если твоя кнопка называется не buttonStart,
                // замени buttonStart на настоящее имя кнопки Старт.
                Start_Button.Text = "Стоп";
            }
            else
            {
                spaceTimer.Stop();
                spaceAnimationStarted = false;

                // Если твоя кнопка называется не buttonStart,
                // замени buttonStart на настоящее имя кнопки Старт.
                Start_Button.Text = "Старт";
            }
        }

        private void SpaceTimer_Tick(object? sender, EventArgs e)
        {
            shipAngle1 += shipSpeed1;
            shipAngle2 += shipSpeed2;

            if (shipAngle1 > 2 * Math.PI)
                shipAngle1 -= 2 * Math.PI;

            if (shipAngle2 < -2 * Math.PI)
                shipAngle2 += 2 * Math.PI;

            DrawSpaceScene();
        }

        private void DrawSpaceScene()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            spaceCenterX = pictureBox1.Width / 2;
            spaceCenterY = pictureBox1.Height / 2;
            orbitRadius = Math.Min(pictureBox1.Width, pictureBox1.Height) / 3;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(spaceBackColor);
            }

            DrawOrbit(bmp, spaceCenterX, spaceCenterY, orbitRadius);
            DrawEarth(bmp, spaceCenterX, spaceCenterY, orbitRadius / 4);

            int x1 = spaceCenterX + (int)(orbitRadius * Math.Cos(shipAngle1));
            int y1 = spaceCenterY + (int)(orbitRadius * Math.Sin(shipAngle1));

            int x2 = spaceCenterX + (int)(orbitRadius * Math.Cos(shipAngle2));
            int y2 = spaceCenterY + (int)(orbitRadius * Math.Sin(shipAngle2));

            DrawShip(bmp, x1, y1, shipAngle1 + Math.PI / 2, y1, ship1Color);
            DrawShip(bmp, x2, y2, shipAngle2 - Math.PI / 2, y2, ship2Color);

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void DrawEarth(Bitmap bmp, int centerX, int centerY, int radius)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (SolidBrush brush = new SolidBrush(earthFillColor))
                using (Pen pen = new Pen(earthBorderColor, 2))
                {
                    g.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
                    g.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
                }

                using (Pen pen = new Pen(Color.DarkCyan, 1))
                {
                    g.DrawArc(pen, centerX - radius / 2, centerY - radius, radius, radius * 2, 90, 180);
                    g.DrawArc(pen, centerX - radius / 2, centerY - radius, radius, radius * 2, -90, 180);
                    g.DrawLine(pen, centerX - radius, centerY, centerX + radius, centerY);
                }
            }
        }

        private void DrawOrbit(Bitmap bmp, int centerX, int centerY, int radius)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(orbitColor, 1))
            {
                g.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
            }
        }

        private void DrawShip(Bitmap bmp, int x, int y, double angle, int currentY, Color color)
        {
            double t = (double)(spaceCenterY + orbitRadius - currentY) / (2.0 * orbitRadius);

            if (t < 0) t = 0;
            if (t > 1) t = 1;

            double scale = 0.6 + t * 1.0;

            PointF[] body =
            {
        new PointF(16, 0),
        new PointF(-10, -8),
        new PointF(-6, 0),
        new PointF(-10, 8)
    };

            PointF[] leftWing =
            {
        new PointF(-4, -5),
        new PointF(-18, -14),
        new PointF(-10, -2)
    };

            PointF[] rightWing =
            {
        new PointF(-4, 5),
        new PointF(-18, 14),
        new PointF(-10, 2)
    };

            PointF[] flame =
            {
        new PointF(-8, -4),
        new PointF(-20, 0),
        new PointF(-8, 4)
    };

            Point[] bodyScreen = TransformPoints(body, x, y, angle, scale);
            Point[] leftWingScreen = TransformPoints(leftWing, x, y, angle, scale);
            Point[] rightWingScreen = TransformPoints(rightWing, x, y, angle, scale);
            Point[] flameScreen = TransformPoints(flame, x, y, angle, scale);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(60, color)))
                using (Pen pen = new Pen(color, 2))
                using (Pen flamePen = new Pen(Color.Orange, 1))
                {
                    g.FillPolygon(brush, bodyScreen);
                    g.DrawPolygon(pen, bodyScreen);

                    g.DrawPolygon(pen, leftWingScreen);
                    g.DrawPolygon(pen, rightWingScreen);

                    g.DrawPolygon(flamePen, flameScreen);
                }
            }
        }

        private Point[] TransformPoints(PointF[] sourcePoints, int dx, int dy, double angle, double scale)
        {
            Point[] result = new Point[sourcePoints.Length];

            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);

            for (int i = 0; i < sourcePoints.Length; i++)
            {
                double xs = sourcePoints[i].X * scale;
                double ys = sourcePoints[i].Y * scale;

                double xr = xs * cosA - ys * sinA;
                double yr = xs * sinA + ys * cosA;

                result[i] = new Point(
                    dx + (int)Math.Round(xr),
                    dy + (int)Math.Round(yr));
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartStopSpaceAnimation();
        }

        private void Button_treygolniki_Click(object sender, EventArgs e)
        {
            // Устанавливаем, чтобы воспринимались клавиши
            this.KeyPreview = true;

            // Инициализация геометрии правильных треугольников (радиус 80)
            double R = 80;
            double cos30 = Math.Cos(30 * Math.PI / 180);
            double sin30 = Math.Sin(30 * Math.PI / 180);

            // Вершины треугольника относительно центра (0,0)
            // Точка 1 (верх), Точка 2 (право-низ), Точка 3 (лево-низ)
            tri1[0, 0] = 0; tri1[0, 1] = -R; tri1[0, 2] = 1;
            tri1[1, 0] = R * cos30; tri1[1, 1] = R * sin30; tri1[1, 2] = 1;
            tri1[2, 0] = -R * cos30; tri1[2, 1] = R * sin30; tri1[2, 2] = 1;

            // Второй треугольник такой же (копия)
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) tri2[i, j] = tri1[i, j];

            // Настройка и запуск таймера
            if (taskTimer == null)
            {
                taskTimer = new System.Windows.Forms.Timer();
                taskTimer.Interval = 40;
                taskTimer.Tick += (s, ev) => TaskTimer_Tick();
            }
            taskTimer.Start();
        }
        private void TaskTimer_Tick()
        {
            // Обновление вращения
            angle1 += speed1;
            angle2 += speed2;

            // Обновление масштаба 1 (Пульсация)
            scale1 += scaleStep1;
            if (scale1 > 2.0 || scale1 < 0.5) scaleStep1 = -scaleStep1;

            // Обновление масштаба 2 (Пульсация)
            scale2 += scaleStep2;
            if (scale2 > 2.0 || scale2 < 0.5) scaleStep2 = -scaleStep2;

            DrawTriangles();
        }
        private void DrawTriangles()
        {
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0) return;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // Центр экрана
                int cx = pictureBox1.Width / 2;
                int cy = pictureBox1.Height / 2;

                // Обработка первого треугольника 
                double[,] m1 = tri1;
                m1 = Multiply_matr_double(m1, Init_matr_scale(scale1));
                m1 = Multiply_matr_double(m1, Init_matr_rotate(angle1));
                m1 = Multiply_matr_double(m1, Init_matr_sdv_double(cx, cy));

                using (Pen pen1 = new Pen(Color.Blue, 2))
                {
                    DrawLineDouble(g, pen1, m1, 0, 1);
                    DrawLineDouble(g, pen1, m1, 1, 2);
                    DrawLineDouble(g, pen1, m1, 2, 0);
                }

                //  Обработка второго треугольника 
                double[,] m2 = tri2;
                m2 = Multiply_matr_double(m2, Init_matr_scale(scale2));
                m2 = Multiply_matr_double(m2, Init_matr_rotate(angle2));
                m2 = Multiply_matr_double(m2, Init_matr_sdv_double(cx, cy));

                using (Pen pen2 = new Pen(Color.Red, 2))
                {
                    DrawLineDouble(g, pen2, m2, 0, 1);
                    DrawLineDouble(g, pen2, m2, 1, 2);
                    DrawLineDouble(g, pen2, m2, 2, 0);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void Button_treygolniki_KeyDown(object sender, KeyEventArgs e)
        {
            // Управление первым треугольником
            if (e.KeyCode == Keys.W) speed1 += 0.5;
            if (e.KeyCode == Keys.S) speed1 -= 0.5;
            if (e.KeyCode == Keys.R) speed1 = -speed1; // Реверс

            // Управление вторым треугольником
            if (e.KeyCode == Keys.Up) speed2 += 0.5;
            if (e.KeyCode == Keys.Down) speed2 -= 0.5;
            if (e.KeyCode == Keys.Enter) speed2 = -speed2; // Реверс
        }

        private void GoTrain_Button_Click(object sender, EventArgs e)
        {
            using (Train train = new Train())
            {
                train.ShowDialog();
            }
        }
    }
}