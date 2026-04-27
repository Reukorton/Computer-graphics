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

namespace LR1T2
{
    /// <summary>
    /// Форма лабораторной работы №3.
    /// Реализует построение двумерных фигур, аффинные преобразования,
    /// настройку цвета и стиля линии, а также переход к индивидуальному заданию.
    /// </summary>
    public partial class Form4 : Form
    {
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
            ImageClear();
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
    }
}