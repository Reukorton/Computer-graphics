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
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        #endregion

        #region Поля настройки линии

        /// <summary>
        /// Цвет линии многогранника.
        /// </summary>
        private Color figureLineColor = Color.Black;

        /// <summary>
        /// Толщина линии многогранника.
        /// </summary>
        private float figureLineWidth = 2;

        /// <summary>
        /// Стиль линии многогранника.
        /// </summary>
        private DashStyle figureLineStyle = DashStyle.Solid;

        /// <summary>
        /// Шаг пунктира для пунктирной линии.
        /// </summary>
        private float dashStep = 4;

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
        /// </summary>
        public Form6()
        {
            InitializeComponent();

            InitializeComboBoxes();

            CreateTetrahedron();
        }

        /// <summary>
        /// Заполняет выпадающие списки начальными значениями.
        /// </summary>
        private void InitializeComboBoxes()
        {
            comboBoxFigure.Items.Clear();
            comboBoxFigure.Items.Add("Вариант 1 — Тетраэдр");
            comboBoxFigure.Items.Add("Вариант 2 — Шестигранник из треугольников(Дудник)");
            comboBoxFigure.Items.Add("Вариант 10 — поверхность (Байдин)");
            comboBoxFigure.Items.Add("Вариант 3 — поверхность (Миронов)");
            comboBoxFigure.SelectedIndex = 0;

            comboBoxAction.Items.Clear();
            comboBoxAction.Items.Add("Перемещение");
            comboBoxAction.Items.Add("Масштабирование");
            comboBoxAction.Items.Add("Вращение");
            comboBoxAction.Items.Add("Отражение");
            comboBoxAction.SelectedIndex = 0;

            comboBoxAxis.Items.Clear();
            comboBoxAxis.Items.Add("X");
            comboBoxAxis.Items.Add("Y");
            comboBoxAxis.Items.Add("Z");
            comboBoxAxis.Items.Add("XY");
            comboBoxAxis.Items.Add("XZ");
            comboBoxAxis.Items.Add("YZ");
            comboBoxAxis.Items.Add("XYZ");
            comboBoxAxis.SelectedIndex = 0;

            comboBoxLineStyle.Items.Clear();
            comboBoxLineStyle.Items.Add("Сплошная");
            comboBoxLineStyle.Items.Add("Пунктирная");
            comboBoxLineStyle.SelectedIndex = 0;
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

            if (comboBoxFigure.SelectedIndex == 1)
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

        #region Аналитическая поверхность

        /// <summary>
        /// Вычисляет значение функции индивидуального задания.
        /// Вариант 10: z = e^(sin(x) + y^2).
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <returns>Координата Z.</returns>
        private double GetSurfaceZVariant10(double x, double y)
        {
            return Math.Exp(Math.Sin(x) + y * y);
        }

        /// <summary>
        /// Вычисляет значение функции индивидуального задания.
        /// Вариант 3: z = (sin(x) + cos(y))^2.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <returns>Координата Z.</returns>
        private double GetSurfaceZVariant3(double x, double y)
        {
            double value = Math.Sin(x) + Math.Cos(y);

            return value * value;
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

            if (comboBoxFigure.SelectedIndex == 2)
            {
                DrawSurfaceVariant10(g);
            }
            else if (comboBoxFigure.SelectedIndex == 3)
            {
                DrawSurfaceVariant3(g);
            }
            else
            {
                DrawPolyhedron(g);
            }
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

            using (Pen pen = CreateFigurePen())
            {
                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    int a = edges[i, 0];
                    int b = edges[i, 1];

                    g.DrawLine(pen, points[a], points[b]);
                }
            }
        }


        /// <summary>
        /// Рисует график аналитической поверхности варианта 10:
        /// z = e^(sin(x) + y^2), x ∈ [-3; 3], y ∈ [-3; 3].
        /// Поверхность отображается в виде каркасной сетки.
        /// </summary>
        /// <param name="g">Графический контекст.</param>
        private void DrawSurfaceVariant10(Graphics g)
        {
            double min = -3;
            double max = 3;
            double step = 0.3;
            double zScale = 0.02;

            using (Pen pen = CreateFigurePen())
            {
                for (double y = min; y <= max; y += step)
                {
                    PointF previousPoint = ProjectSurfacePointVariant10(min, y, zScale);

                    for (double x = min + step; x <= max; x += step)
                    {
                        PointF currentPoint = ProjectSurfacePointVariant10(x, y, zScale);

                        g.DrawLine(pen, previousPoint, currentPoint);

                        previousPoint = currentPoint;
                    }
                }

                for (double x = min; x <= max; x += step)
                {
                    PointF previousPoint = ProjectSurfacePointVariant10(x, min, zScale);

                    for (double y = min + step; y <= max; y += step)
                    {
                        PointF currentPoint = ProjectSurfacePointVariant10(x, y, zScale);

                        g.DrawLine(pen, previousPoint, currentPoint);

                        previousPoint = currentPoint;
                    }
                }
            }
        }

        /// <summary>
        /// Рисует график аналитической поверхности варианта 3:
        /// z = (sin(x) + cos(y))^2, x ∈ [-3; 3], y ∈ [-3; 3].
        /// Поверхность отображается в виде каркасной сетки.
        /// </summary>
        /// <param name="g">Графический контекст.</param>
        private void DrawSurfaceVariant3(Graphics g)
        {
            double min = -3;
            double max = 3;
            double step = 0.3;
            double zScale = 0.7;

            using (Pen pen = CreateFigurePen())
            {
                for (double y = min; y <= max; y += step)
                {
                    PointF previousPoint = ProjectSurfacePointVariant3(min, y, zScale);

                    for (double x = min + step; x <= max; x += step)
                    {
                        PointF currentPoint = ProjectSurfacePointVariant3(x, y, zScale);

                        g.DrawLine(pen, previousPoint, currentPoint);

                        previousPoint = currentPoint;
                    }
                }

                for (double x = min; x <= max; x += step)
                {
                    PointF previousPoint = ProjectSurfacePointVariant3(x, min, zScale);

                    for (double y = min + step; y <= max; y += step)
                    {
                        PointF currentPoint = ProjectSurfacePointVariant3(x, y, zScale);

                        g.DrawLine(pen, previousPoint, currentPoint);

                        previousPoint = currentPoint;
                    }
                }
            }
        }

        /// <summary>
        /// Создает перо для рисования ребер многогранника
        /// с учетом выбранного цвета, толщины и стиля линии.
        /// </summary>
        /// <returns>Перо для рисования многогранника.</returns>
        private Pen CreateFigurePen()
        {
            Pen pen = new Pen(figureLineColor, figureLineWidth);

            if (figureLineStyle == DashStyle.Dash)
            {
                pen.DashPattern = new float[] { dashStep, dashStep };
            }
            else
            {
                pen.DashStyle = DashStyle.Solid;
            }

            return pen;
        }

        #endregion

        #region Настройка линии

        /// <summary>
        /// Открывает выбор цвета линии многогранника.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                figureLineColor = colorDialog1.Color;
                pictureBox1.Invalidate();
            }
        }

        /// <summary>
        /// Изменяет толщину линии многогранника.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void NumericLineWidth_ValueChanged(object sender, EventArgs e)
        {
            figureLineWidth = (float)numericLineWidth.Value;
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Изменяет стиль линии многогранника.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ComboBoxLineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLineStyle.SelectedIndex == 0)
            {
                figureLineStyle = DashStyle.Solid;
            }
            else
            {
                figureLineStyle = DashStyle.Dash;
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Изменяет шаг пунктирной линии.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void NumericDashStep_ValueChanged(object sender, EventArgs e)
        {
            dashStep = (float)numericDashStep.Value;
            pictureBox1.Invalidate();
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
        /// Вычисляет точку аналитической поверхности варианта 10
        /// и переводит ее в экранные координаты.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="zScale">Коэффициент уменьшения высоты поверхности.</param>
        /// <returns>Точка на плоскости экрана.</returns>
        private PointF ProjectSurfacePointVariant10(double x, double y, double zScale)
        {
            double z = GetSurfaceZVariant10(x, y) * zScale;

            Point3D point = new Point3D(x, z, y);

            return ProjectPoint(point);
        }

        /// <summary>
        /// Вычисляет точку аналитической поверхности варианта 3
        /// и переводит ее в экранные координаты.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="zScale">Коэффициент изменения высоты поверхности.</param>
        /// <returns>Точка на плоскости экрана.</returns>
        private PointF ProjectSurfacePointVariant3(double x, double y, double zScale)
        {
            double z = GetSurfaceZVariant3(x, y) * zScale;

            Point3D point = new Point3D(x, z, y);

            return ProjectPoint(point);
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

        private void comboBoxAxis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Описание вершин тетраэдра (4 вершины)
        private Point3D[] originalVertices = new Point3D[]
        {
            new Point3D(0, 100, 0),                               // Верхняя точка на оси Y
            new Point3D(94.28, -33.33, 0),                        // Передняя правая
            new Point3D(-47.14, -33.33, 81.65),                   // Левая ближняя
            new Point3D(-47.14, -33.33, -81.65)                   // Задняя дальняя
        };

        // Массив измененных вершин после всех трансформаций
        private Point3D[] transformedVertices = new Point3D[4];

        // Индексы вершин для 4-х треугольных граней. 
        // ВАЖНО: Обход вершин задан ПРОТИВ часовой стрелки, если смотреть СНАРУЖИ грани!
        private int[][] faces = new int[][]
        {
            new int[] { 0, 2, 1 }, // Грань 1
            new int[] { 0, 3, 2 }, // Грань 2
            new int[] { 0, 1, 3 }, // Грань 3
            new int[] { 1, 2, 3 }  // Основание (Грань 4)
        };
        private PointF ProjectToDimetry(Point3D p)
        {
            // Стандартные углы для кабинетной/диметрической проекции:
            double alpha = Math.PI * 7.16 / 180.0;  // 7 градусов 10 минут
            double beta = Math.PI * 41.42 / 180.0;  // 41 градус 25 минут

            // Расчет экранных координат относительно центра PictureBox
            double screenX = pictureBox1.Width / 2.0 + (p.X * Math.Cos(alpha) - p.Z * Math.Cos(beta)) * reflectX * scaleX + moveX;
            double screenY = pictureBox1.Height / 2.0 - (p.Y + p.X * Math.Sin(alpha) + p.Z * Math.Sin(beta)) * reflectY * scaleY + moveY;

            return new PointF((float)screenX, (float)screenY);
        }
        private Point3D RotateAroundCustomAxis(Point3D p, double angleDegrees)
        {
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            // Направляющие косинусы для оси (1,1,1)
            double l = 1.0 / Math.Sqrt(3);
            double m = 1.0 / Math.Sqrt(3);
            double n = 1.0 / Math.Sqrt(3);

            // Матричное умножение для поворота вокруг произвольной оси
            double x = (l * l * (1 - cos) + cos) * p.X + (l * m * (1 - cos) - n * sin) * p.Y + (l * n * (1 - cos) + m * sin) * p.Z;
            double y = (l * m * (1 - cos) + n * sin) * p.X + (m * m * (1 - cos) + cos) * p.Y + (m * n * (1 - cos) - l * sin) * p.Z;
            double z = (l * n * (1 - cos) - m * sin) * p.X + (m * n * (1 - cos) + l * sin) * p.Y + (n * n * (1 - cos) + cos) * p.Z;

            return new Point3D(x, y, z);
        }
        private void btnRotateCustomAxis_Click(object sender, EventArgs e)
        {
            // Циклом перезаписываем ОРИГИНАЛЬНЫЕ вершины, поворачивая их в пространстве
            for (int i = 0; i < originalVertices.Length; i++)
            {
                originalVertices[i] = RotateAroundCustomAxis(originalVertices[i], 5); // Поворот на 5 градусов
            }
            pictureBox1.Invalidate(); // Перерисовываем экран
        }
        private void btnApplyMove_Click(object sender, EventArgs e)
        {
            // Безопасно считываем значения из текстовых полей. Если поле пустое, смещение = 0
            double.TryParse(txtMoveX.Text, out double dx);
            double.TryParse(txtMoveY.Text, out double dy);
            double.TryParse(txtMoveZ.Text, out double dz);

            // Изменяем глобальные переменные смещения
            moveX += dx;
            moveY += dy;
            moveZ += dz;

            pictureBox1.Invalidate(); // Перерисовываем
        }
        private void btnApplyScale_Click(object sender, EventArgs e)
        {
            // Если распарсить не удалось, ставим 1.0 (чтобы объект не сжался в точку)
            if (!double.TryParse(txtScaleX.Text, out double sx)) sx = 1.0;
            if (!double.TryParse(txtScaleY.Text, out double sy)) sy = 1.0;
            if (!double.TryParse(txtScaleZ.Text, out double sz)) sz = 1.0;

            // Умножаем текущие коэффициенты масштаба
            scaleX *= sx;
            scaleY *= sy;
            scaleZ *= sz;

            pictureBox1.Invalidate();
        }
        private void btnRotateX_Click(object sender, EventArgs e)
        {
            rotateX += 10; // Поворот на 10 градусов вокруг X
            pictureBox1.Invalidate();
        }

        private void btnRotateY_Click(object sender, EventArgs e)
        {
            rotateY += 10; // Поворот на 10 градусов вокруг Y
            pictureBox1.Invalidate();
        }

        private void btnRotateZ_Click(object sender, EventArgs e)
        {
            rotateZ += 10; // Поворот на 10 градусов вокруг Z
            pictureBox1.Invalidate();
        }
        private bool IsFaceVisible(Point3D p0, Point3D p1, Point3D p2)
        {
            // Векторы двух ребер грани
            double ax = p1.X - p0.X;
            double ay = p1.Y - p0.Y;
            double az = p1.Z - p0.Z;

            double bx = p2.X - p0.X;
            double by = p2.Y - p0.Y;
            double bz = p2.Z - p0.Z;

            // Вычисляем только Z-компоненту вектора нормали (Cross Product)
            double normalZ = ax * by - ay * bx;

            // Если normalZ > 0, грань видима наблюдателю
            return normalZ > 0;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Шаг 1. Переносим текущие координаты с учетом ручных трансформаций (если они есть)
            for (int i = 0; i < originalVertices.Length; i++)
            {
                // Сюда можно также заложить базовое перемещение/масштабирование, если не делать его внутри проекции
                transformedVertices[i] = originalVertices[i];
            }

            // Шаг 2. Заводим перья
            Pen visiblePen = new Pen(Color.Black, 2f);
            Pen hiddenPen = new Pen(Color.Blue, 1f) { DashPattern = new float[] { 4, 4 } }; // Пунктирная линия 

            // Шаг 3. Определяем видимость граней
            bool[] isFaceVisible = new bool[faces.Length];
            for (int i = 0; i < faces.Length; i++)
            {
                isFaceVisible[i] = IsFaceVisible(
                    transformedVertices[faces[i][0]],
                    transformedVertices[faces[i][1]],
                    transformedVertices[faces[i][2]]
                );
            }

            // Шаг 4. Рисуем систему координат и ось вращения (Задание 2) [cite: 8, 30, 192, 233]
            // Направляющая линия оси под 45 градусов (проходит из (-200,-200,-200) в (200,200,200))
            PointF axisStart = ProjectToDimetry(new Point3D(-200, -200, -200));
            PointF axisEnd = ProjectToDimetry(new Point3D(200, 200, 200));
            g.DrawLine(new Pen(Color.Red, 1.5f) { DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot }, axisStart, axisEnd);

            // Шаг 5. Отрисовка ребер многогранника
            // Перебираем все пары вершин, проверяя их смежность с видимыми гранями
            for (int i = 0; i < faces.Length; i++)
            {
                Pen currentPen = isFaceVisible[i] ? visiblePen : hiddenPen;

                for (int j = 0; j < 3; j++)
                {
                    Point3D pStart3D = transformedVertices[faces[i][j]];
                    Point3D pEnd3D = transformedVertices[faces[i][(j + 1) % 3]];

                    PointF pStart2D = ProjectToDimetry(pStart3D);
                    PointF pEnd2D = ProjectToDimetry(pEnd3D);

                    g.DrawLine(currentPen, pStart2D, pEnd2D);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}   