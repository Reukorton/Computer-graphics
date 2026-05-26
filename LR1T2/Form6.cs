using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LR1T2
{
    /// <summary>
    /// Форма лабораторной работы №4.
    /// Реализует построение и преобразование трехмерных многогранников
    /// с использованием векторно-полигональной модели, матриц 3D-преобразований
    /// и ортогональной проекции.
    /// </summary>
    public partial class Form6 : Form
    {
        #region Структуры

        /// <summary>
        /// Описывает точку в трехмерном пространстве.
        /// Координаты точки задаются в мировой системе координат.
        /// </summary>
        private struct Point3D
        {
            /// <summary>
            /// Координата точки по оси X.
            /// </summary>
            public double X;

            /// <summary>
            /// Координата точки по оси Y.
            /// </summary>
            public double Y;

            /// <summary>
            /// Координата точки по оси Z.
            /// </summary>
            public double Z;

            /// <summary>
            /// Создает точку в трехмерном пространстве.
            /// </summary>
            /// <param name="x">Координата по оси X.</param>
            /// <param name="y">Координата по оси Y.</param>
            /// <param name="z">Координата по оси Z.</param>
            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        #endregion

        #region Поля фигуры

        /// <summary>
        /// Массив вершин текущего многогранника в мировых координатах.
        /// </summary>
        private Point3D[] vertices;

        /// <summary>
        /// Массив ребер текущего многогранника.
        /// Каждое ребро задается двумя индексами вершин.
        /// </summary>
        private int[,] edges;

        #endregion

        #region Поля начального отображения

        /// <summary>
        /// Угол начального поворота вида вокруг оси X.
        /// Используется для того, чтобы форма многогранника была видна на экране.
        /// </summary>
        private double viewAngleX = -25;

        /// <summary>
        /// Угол начального поворота вида вокруг оси Y.
        /// Используется для того, чтобы форма многогранника была видна на экране.
        /// </summary>
        private double viewAngleY = 35;

        /// <summary>
        /// Масштаб перевода мировых координат в экранные координаты.
        /// </summary>
        private double screenScale = 100;

        #endregion

        #region Поля преобразований

        /// <summary>
        /// Смещение многогранника по оси X.
        /// </summary>
        private double moveX = 0;

        /// <summary>
        /// Смещение многогранника по оси Y.
        /// </summary>
        private double moveY = 0;

        /// <summary>
        /// Смещение многогранника по оси Z.
        /// </summary>
        private double moveZ = 0;

        /// <summary>
        /// Угол вращения многогранника вокруг оси X.
        /// </summary>
        private double rotateX = 0;

        /// <summary>
        /// Угол вращения многогранника вокруг оси Y.
        /// </summary>
        private double rotateY = 0;

        /// <summary>
        /// Угол вращения многогранника вокруг оси Z.
        /// </summary>
        private double rotateZ = 0;

        /// <summary>
        /// Коэффициент масштабирования по оси X.
        /// </summary>
        private double scaleX = 1;

        /// <summary>
        /// Коэффициент масштабирования по оси Y.
        /// </summary>
        private double scaleY = 1;

        /// <summary>
        /// Коэффициент масштабирования по оси Z.
        /// </summary>
        private double scaleZ = 1;

        /// <summary>
        /// Коэффициент отражения по оси X.
        /// Значение -1 дает отражение относительно плоскости YZ.
        /// </summary>
        private double reflectX = 1;

        /// <summary>
        /// Коэффициент отражения по оси Y.
        /// Значение -1 дает отражение относительно плоскости XZ.
        /// </summary>
        private double reflectY = 1;

        /// <summary>
        /// Коэффициент отражения по оси Z.
        /// Значение -1 дает отражение относительно плоскости XY.
        /// </summary>
        private double reflectZ = 1;

        #endregion

        #region Поля автоматического движения

        /// <summary>
        /// Шаг перемещения многогранника.
        /// </summary>
        private double moveStep = 0.1;

        /// <summary>
        /// Шаг вращения многогранника в градусах.
        /// </summary>
        private double rotateStep = 5;

        /// <summary>
        /// Направление автоматического вращения или перемещения.
        /// </summary>
        private int direction = 1;

        /// <summary>
        /// Флаг автоматического вращения.
        /// </summary>
        private bool autoRotation = false;

        /// <summary>
        /// Флаг автоматического перемещения.
        /// </summary>
        private bool autoMoving = false;

        #endregion

        #region Конструктор

        /// <summary>
        /// Инициализирует форму лабораторной работы №4.
        /// Заполняет элементы управления, подключает обработчики событий
        /// и создает начальную фигуру.
        /// </summary>
        public Form6()
        {
            InitializeComponent();

            comboBoxFigure.Items.Add("Вариант 1 — Тетраэдр");
            comboBoxFigure.Items.Add("Вариант 2 — Шестигранник из треугольников");
            comboBoxFigure.SelectedIndex = 0;

            comboBoxAction.Items.Add("Перемещение");
            comboBoxAction.Items.Add("Масштабирование");
            comboBoxAction.Items.Add("Вращение");
            comboBoxAction.Items.Add("Отражение");
            comboBoxAction.SelectedIndex = 0;

            comboBoxAxis.Items.Add("X");
            comboBoxAxis.Items.Add("Y");
            comboBoxAxis.Items.Add("Z");
            comboBoxAxis.Items.Add("XY");
            comboBoxAxis.Items.Add("XZ");
            comboBoxAxis.Items.Add("YZ");
            comboBoxAxis.Items.Add("XYZ");
            comboBoxAxis.SelectedIndex = 0;

            comboBoxFigure.SelectedIndexChanged += ComboBoxFigure_SelectedIndexChanged;

            pictureBox1.Paint += PictureBox1_Paint;

            btnMinus.Click += BtnMinus_Click;
            btnPlus.Click += BtnPlus_Click;

            btnAutoRotate.Click += BtnAutoRotate_Click;
            btnAutoMove.Click += BtnAutoMove_Click;
            btnDirection.Click += BtnDirection_Click;
            btnSpeedMinus.Click += BtnSpeedMinus_Click;
            btnSpeedPlus.Click += BtnSpeedPlus_Click;
            btnReset.Click += BtnReset_Click;

            timer1.Interval = 30;
            timer1.Tick += Timer_Tick;

            CreateTetrahedron();
        }

        #endregion

        #region Создание фигур

        /// <summary>
        /// Обрабатывает изменение выбранной фигуры.
        /// Создает выбранный многогранник и сбрасывает преобразования.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ComboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFigure.SelectedIndex == 0)
            {
                CreateTetrahedron();
            }
            else
            {
                CreateTriangleHexahedron();
            }

            ResetTransformations();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Создает тетраэдр.
        /// Фигура задается массивом вершин и массивом ребер.
        /// </summary>
        private void CreateTetrahedron()
        {
            vertices = new Point3D[]
            {
                new Point3D(0, 1.3, 0),
                new Point3D(-1, -1, -1),
                new Point3D(1, -1, -1),
                new Point3D(0, -1, 1)
            };

            edges = new int[,]
            {
                { 0, 1 },
                { 0, 2 },
                { 0, 3 },
                { 1, 2 },
                { 2, 3 },
                { 3, 1 }
            };
        }

        /// <summary>
        /// Создает шестигранник, образованный треугольниками.
        /// Фигура задается массивом вершин и массивом ребер.
        /// </summary>
        private void CreateTriangleHexahedron()
        {
            vertices = new Point3D[]
            {
                new Point3D(0, 1.4, 0),
                new Point3D(0, -1.4, 0),
                new Point3D(1.2, 0, 0),
                new Point3D(-0.6, 0, 1),
                new Point3D(-0.6, 0, -1)
            };

            edges = new int[,]
            {
                { 0, 2 },
                { 0, 3 },
                { 0, 4 },
                { 1, 2 },
                { 1, 3 },
                { 1, 4 },
                { 2, 3 },
                { 3, 4 },
                { 4, 2 }
            };
        }

        #endregion

        #region Рисование

        /// <summary>
        /// Выполняет отрисовку системы координат и текущего многогранника.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события рисования.</param>
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            DrawCoordinateSystem(g);
            DrawPolyhedron(g);
        }

        /// <summary>
        /// Рисует трехмерную систему координат в ортогональной проекции.
        /// </summary>
        /// <param name="g">Графический контекст.</param>
        private void DrawCoordinateSystem(Graphics g)
        {
            PointF center = ProjectAxisPoint(new Point3D(0, 0, 0));
            PointF xEnd = ProjectAxisPoint(new Point3D(2, 0, 0));
            PointF yEnd = ProjectAxisPoint(new Point3D(0, 2, 0));
            PointF zEnd = ProjectAxisPoint(new Point3D(0, 0, 2));

            using (Pen xPen = new Pen(Color.Red, 1))
            using (Pen yPen = new Pen(Color.Green, 1))
            using (Pen zPen = new Pen(Color.Blue, 1))
            using (Font font = new Font("Arial", 9))
            {
                g.DrawLine(xPen, center, xEnd);
                g.DrawLine(yPen, center, yEnd);
                g.DrawLine(zPen, center, zEnd);

                g.DrawString("X", font, Brushes.Red, xEnd);
                g.DrawString("Y", font, Brushes.Green, yEnd);
                g.DrawString("Z", font, Brushes.Blue, zEnd);
            }
        }

        /// <summary>
        /// Рисует текущий многогранник по его вершинам и ребрам.
        /// </summary>
        /// <param name="g">Графический контекст.</param>
        private void DrawPolyhedron(Graphics g)
        {
            PointF[] points = new PointF[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                points[i] = ProjectPoint(vertices[i]);
            }

            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    int a = edges[i, 0];
                    int b = edges[i, 1];

                    g.DrawLine(pen, points[a], points[b]);
                }
            }
        }

        #endregion

        #region Проекция и преобразование точек

        /// <summary>
        /// Преобразует трехмерную точку фигуры и переводит ее в экранные координаты.
        /// </summary>
        /// <param name="point">Исходная точка в мировых координатах.</param>
        /// <returns>Точка на плоскости экрана.</returns>
        private PointF ProjectPoint(Point3D point)
        {
            Point3D transformed = TransformPoint(point);
            Point3D viewed = ViewPoint(transformed);

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            float screenX = (float)(centerX + viewed.X * screenScale);
            float screenY = (float)(centerY - viewed.Y * screenScale);

            return new PointF(screenX, screenY);
        }

        /// <summary>
        /// Переводит точку системы координат в экранные координаты.
        /// К осям применяется только начальный поворот вида.
        /// </summary>
        /// <param name="point">Точка оси в мировой системе координат.</param>
        /// <returns>Точка на плоскости экрана.</returns>
        private PointF ProjectAxisPoint(Point3D point)
        {
            Point3D viewed = ViewPoint(point);

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            float screenX = (float)(centerX + viewed.X * screenScale);
            float screenY = (float)(centerY - viewed.Y * screenScale);

            return new PointF(screenX, screenY);
        }

        /// <summary>
        /// Выполняет матричные преобразования точки многогранника:
        /// масштабирование, отражение, вращение и перенос.
        /// </summary>
        /// <param name="point">Исходная точка в мировой системе координат.</param>
        /// <returns>Преобразованная трехмерная точка.</returns>
        private Point3D TransformPoint(Point3D point)
        {
            Point3D result = point;

            result = MultiplyPointByMatrix(result, GetScaleMatrix(scaleX, scaleY, scaleZ));
            result = MultiplyPointByMatrix(result, GetScaleMatrix(reflectX, reflectY, reflectZ));
            result = MultiplyPointByMatrix(result, GetRotationXMatrix(rotateX));
            result = MultiplyPointByMatrix(result, GetRotationYMatrix(rotateY));
            result = MultiplyPointByMatrix(result, GetRotationZMatrix(rotateZ));
            result = MultiplyPointByMatrix(result, GetTranslationMatrix(moveX, moveY, moveZ));

            return result;
        }

        /// <summary>
        /// Выполняет начальный поворот вида, чтобы форма многогранника была видна на экране.
        /// </summary>
        /// <param name="point">Преобразованная точка.</param>
        /// <returns>Точка после поворота вида.</returns>
        private Point3D ViewPoint(Point3D point)
        {
            Point3D result = point;

            result = MultiplyPointByMatrix(result, GetRotationXMatrix(viewAngleX));
            result = MultiplyPointByMatrix(result, GetRotationYMatrix(viewAngleY));

            return result;
        }

        /// <summary>
        /// Умножает точку в однородных координатах на матрицу преобразования 4x4.
        /// </summary>
        /// <param name="point">Точка в трехмерном пространстве.</param>
        /// <param name="matrix">Матрица преобразования 4x4.</param>
        /// <returns>Точка после применения матрицы преобразования.</returns>
        private Point3D MultiplyPointByMatrix(Point3D point, double[,] matrix)
        {
            double x = point.X * matrix[0, 0] +
                       point.Y * matrix[1, 0] +
                       point.Z * matrix[2, 0] +
                       matrix[3, 0];

            double y = point.X * matrix[0, 1] +
                       point.Y * matrix[1, 1] +
                       point.Z * matrix[2, 1] +
                       matrix[3, 1];

            double z = point.X * matrix[0, 2] +
                       point.Y * matrix[1, 2] +
                       point.Z * matrix[2, 2] +
                       matrix[3, 2];

            return new Point3D(x, y, z);
        }

        #endregion

        #region Матрицы преобразований

        /// <summary>
        /// Создает матрицу переноса в трехмерном пространстве.
        /// </summary>
        /// <param name="dx">Смещение по оси X.</param>
        /// <param name="dy">Смещение по оси Y.</param>
        /// <param name="dz">Смещение по оси Z.</param>
        /// <returns>Матрица переноса 4x4.</returns>
        private double[,] GetTranslationMatrix(double dx, double dy, double dz)
        {
            return new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { dx, dy, dz, 1 }
            };
        }

        /// <summary>
        /// Создает матрицу масштабирования в трехмерном пространстве.
        /// </summary>
        /// <param name="sx">Коэффициент масштабирования по оси X.</param>
        /// <param name="sy">Коэффициент масштабирования по оси Y.</param>
        /// <param name="sz">Коэффициент масштабирования по оси Z.</param>
        /// <returns>Матрица масштабирования 4x4.</returns>
        private double[,] GetScaleMatrix(double sx, double sy, double sz)
        {
            return new double[,]
            {
                { sx, 0, 0, 0 },
                { 0, sy, 0, 0 },
                { 0, 0, sz, 0 },
                { 0, 0, 0, 1 }
            };
        }

        /// <summary>
        /// Создает матрицу вращения вокруг оси X.
        /// </summary>
        /// <param name="angle">Угол вращения в градусах.</param>
        /// <returns>Матрица вращения вокруг оси X.</returns>
        private double[,] GetRotationXMatrix(double angle)
        {
            double rad = angle * Math.PI / 180.0;

            return new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(rad), Math.Sin(rad), 0 },
                { 0, -Math.Sin(rad), Math.Cos(rad), 0 },
                { 0, 0, 0, 1 }
            };
        }

        /// <summary>
        /// Создает матрицу вращения вокруг оси Y.
        /// </summary>
        /// <param name="angle">Угол вращения в градусах.</param>
        /// <returns>Матрица вращения вокруг оси Y.</returns>
        private double[,] GetRotationYMatrix(double angle)
        {
            double rad = angle * Math.PI / 180.0;

            return new double[,]
            {
                { Math.Cos(rad), 0, -Math.Sin(rad), 0 },
                { 0, 1, 0, 0 },
                { Math.Sin(rad), 0, Math.Cos(rad), 0 },
                { 0, 0, 0, 1 }
            };
        }

        /// <summary>
        /// Создает матрицу вращения вокруг оси Z.
        /// </summary>
        /// <param name="angle">Угол вращения в градусах.</param>
        /// <returns>Матрица вращения вокруг оси Z.</returns>
        private double[,] GetRotationZMatrix(double angle)
        {
            double rad = angle * Math.PI / 180.0;

            return new double[,]
            {
                { Math.Cos(rad), Math.Sin(rad), 0, 0 },
                { -Math.Sin(rad), Math.Cos(rad), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
        }

        #endregion

        #region Управление преобразованиями

        /// <summary>
        /// Выполняет выбранное преобразование в отрицательном направлении.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            ApplySelectedTransformation(-1);
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Выполняет выбранное преобразование в положительном направлении.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            ApplySelectedTransformation(1);
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Выполняет преобразование, выбранное пользователем на форме.
        /// </summary>
        /// <param name="sign">Направление выполнения преобразования.</param>
        private void ApplySelectedTransformation(int sign)
        {
            string action = comboBoxAction.SelectedItem.ToString();
            string axis = comboBoxAxis.SelectedItem.ToString();

            if (action == "Перемещение")
            {
                ApplyMove(axis, sign);
            }

            if (action == "Масштабирование")
            {
                ApplyScale(axis, sign);
            }

            if (action == "Вращение")
            {
                ApplyRotation(axis, sign);
            }

            if (action == "Отражение")
            {
                ApplyReflection(axis);
            }
        }

        /// <summary>
        /// Изменяет параметры переноса по выбранной оси или группе осей.
        /// </summary>
        /// <param name="axis">Ось или группа осей.</param>
        /// <param name="sign">Направление переноса.</param>
        private void ApplyMove(string axis, int sign)
        {
            double value = moveStep * sign;

            if (axis.Contains("X"))
            {
                moveX += value;
            }

            if (axis.Contains("Y"))
            {
                moveY += value;
            }

            if (axis.Contains("Z"))
            {
                moveZ += value;
            }
        }

        /// <summary>
        /// Изменяет коэффициенты масштабирования по выбранной оси или группе осей.
        /// </summary>
        /// <param name="axis">Ось или группа осей.</param>
        /// <param name="sign">Направление изменения масштаба.</param>
        private void ApplyScale(string axis, int sign)
        {
            double value = 0.1 * sign;

            if (axis.Contains("X"))
            {
                scaleX += value;
            }

            if (axis.Contains("Y"))
            {
                scaleY += value;
            }

            if (axis.Contains("Z"))
            {
                scaleZ += value;
            }
        }

        /// <summary>
        /// Изменяет углы вращения вокруг выбранной оси или группы осей.
        /// </summary>
        /// <param name="axis">Ось или группа осей.</param>
        /// <param name="sign">Направление вращения.</param>
        private void ApplyRotation(string axis, int sign)
        {
            double value = rotateStep * sign;

            if (axis.Contains("X"))
            {
                rotateX += value;
            }

            if (axis.Contains("Y"))
            {
                rotateY += value;
            }

            if (axis.Contains("Z"))
            {
                rotateZ += value;
            }
        }

        /// <summary>
        /// Изменяет параметры отражения.
        /// Отражение реализуется как масштабирование с коэффициентом -1 по нужной оси.
        /// </summary>
        /// <param name="axis">Ось, группа осей или координатная плоскость.</param>
        private void ApplyReflection(string axis)
        {
            if (axis == "X")
            {
                reflectX *= -1;
            }

            if (axis == "Y")
            {
                reflectY *= -1;
            }

            if (axis == "Z")
            {
                reflectZ *= -1;
            }

            if (axis == "XY")
            {
                reflectZ *= -1;
            }

            if (axis == "XZ")
            {
                reflectY *= -1;
            }

            if (axis == "YZ")
            {
                reflectX *= -1;
            }

            if (axis == "XYZ")
            {
                reflectX *= -1;
                reflectY *= -1;
                reflectZ *= -1;
            }
        }

        #endregion

        #region Автоматическое движение

        /// <summary>
        /// Включает или выключает автоматическое вращение.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnAutoRotate_Click(object sender, EventArgs e)
        {
            autoRotation = !autoRotation;
            timer1.Enabled = autoRotation || autoMoving;
        }

        /// <summary>
        /// Включает или выключает автоматическое перемещение.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnAutoMove_Click(object sender, EventArgs e)
        {
            autoMoving = !autoMoving;
            timer1.Enabled = autoRotation || autoMoving;
        }

        /// <summary>
        /// Меняет направление автоматического вращения или перемещения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnDirection_Click(object sender, EventArgs e)
        {
            direction *= -1;
        }

        /// <summary>
        /// Уменьшает скорость автоматического вращения и перемещения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnSpeedMinus_Click(object sender, EventArgs e)
        {
            if (rotateStep > 1)
            {
                rotateStep -= 1;
            }

            if (moveStep > 0.02)
            {
                moveStep -= 0.02;
            }
        }

        /// <summary>
        /// Увеличивает скорость автоматического вращения и перемещения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnSpeedPlus_Click(object sender, EventArgs e)
        {
            rotateStep += 1;
            moveStep += 0.02;
        }

        /// <summary>
        /// Выполняет шаг автоматического вращения или перемещения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события таймера.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (autoRotation)
            {
                rotateY += rotateStep * direction;
            }

            if (autoMoving)
            {
                moveX += moveStep * direction;
            }

            pictureBox1.Invalidate();
        }

        #endregion

        #region Сброс

        /// <summary>
        /// Обрабатывает нажатие кнопки сброса преобразований.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetTransformations();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Сбрасывает все параметры преобразований к исходным значениям.
        /// </summary>
        private void ResetTransformations()
        {
            moveX = 0;
            moveY = 0;
            moveZ = 0;

            rotateX = 0;
            rotateY = 0;
            rotateZ = 0;

            scaleX = 1;
            scaleY = 1;
            scaleZ = 1;

            reflectX = 1;
            reflectY = 1;
            reflectZ = 1;

            direction = 1;
            autoRotation = false;
            autoMoving = false;

            timer1.Enabled = false;
        }

        #endregion
    }
}