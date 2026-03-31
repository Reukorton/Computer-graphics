using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LR1T2
{
    public partial class Form3 : Form
    {
        public int xn, yn, xk, yk;
        Bitmap myBitmap;
        Color currentBorderColor = Color.Red;
        Color currentFillColor = Color.Green;
        Color contourTraceColor = Color.Blue;

        /// <summary>
        /// Прямоугольное окно отсечения.
        /// </summary>
        Rectangle clipRectangle = new Rectangle(120, 80, 180, 140);

        /// <summary>
        /// Начальная и конечная точки отрезка,
        /// который нужно отсечь.
        /// </summary>
        Point clipStart, clipEnd;

        /// <summary>
        /// Признак того, что отрезок для отсечения уже задан.
        /// </summary>
        bool clipLineDefined = false;


        bool useBresenham = false;  // Для использования метода брезенхема

        // НОВЫЕ ПОЛЯ для рисования линий
        int dashStep = 5;                           // Шаг пунктира
        bool isDashed = false;                      // Тип линии (сплошная/пунктирная)
        public Form3()
        {
            InitializeComponent();
            InitializeLineDrawingComponents();
        }
        // Метод для рисования линии с поддержкой сплошной и пунктирной линии

        private void DrawLineWithStyle(int x1, int y1, int x2, int y2, Color color, bool dashed, int dashStep)
        {
            if (myBitmap == null)
                myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

            // Вычисляем длину отрезка
            double dx = x2 - x1;
            double dy = y2 - y1;
            double length = Math.Sqrt(dx * dx + dy * dy);

            if (length == 0)
            {
                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(x1, y1, color);
                else
                    DrawPixel(x1, y1, color);
                return;
            }

            if (!dashed)
            {
                // Рисуем сплошную линию
                DrawLineWithAlgorithm(x1, y1, x2, y2, color);
            }
            else
            {
                // Рисуем пунктирную линию с заданным шагом
                DrawDashedLine(x1, y1, x2, y2, color, dashStep);
            }
        }

        // Метод для рисования сплошной линии (использует ваш CDA алгоритм)
        private void DrawSolidLine(int x1, int y1, int x2, int y2, Color color)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;

            int numberNodes = (int)Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (numberNodes == 0)
            {
                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(x1, y1, color);
                else
                    DrawPixel(x1, y1, color);
                return;
            }

            double xOutput = x1;
            double yOutput = y1;

            double xStep = dx / numberNodes;
            double yStep = dy / numberNodes;

            for (int i = 0; i <= numberNodes; i++)
            {
                int x = (int)Math.Round(xOutput);
                int y = (int)Math.Round(yOutput);

                // Используем вашу логику толщины через ThickLine_СheckBox
                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(x, y, color);
                else
                    DrawPixel(x, y, color);

                xOutput += xStep;
                yOutput += yStep;
            }
        }

        // Новый метод, который выбирает алгоритм
        private void DrawLineWithAlgorithm(int x1, int y1, int x2, int y2, Color color)
        {
            if (useBresenham)
                BresenhamLine(x1, y1, x2, y2, color);  // Брезенхем
            else
                CDA(x1, y1, x2, y2);                    // Ваш CDA
        }

        // Метод для рисования пунктирной линии
        private void DrawDashedLine(int x1, int y1, int x2, int y2, Color color, int dashLength)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            double lineLength = Math.Sqrt(dx * dx + dy * dy);

            if (lineLength == 0) return;

            // Нормализованный вектор направления
            double ux = dx / lineLength;
            double uy = dy / lineLength;

            double currentPos = 0;
            bool draw = true; // Начинаем рисовать

            while (currentPos < lineLength)
            {
                double segmentLength = draw ? dashLength : dashLength;

                // Корректируем последний сегмент
                if (currentPos + segmentLength > lineLength)
                    segmentLength = lineLength - currentPos;

                if (draw && segmentLength > 0)
                {
                    // Вычисляем конец текущего отрезка
                    double endX = x1 + ux * (currentPos + segmentLength);
                    double endY = y1 + uy * (currentPos + segmentLength);

                    // Рисуем отрезок
                    int xStart = (int)Math.Round(x1 + ux * currentPos);
                    int yStart = (int)Math.Round(y1 + uy * currentPos);
                    int xEnd = (int)Math.Round(endX);
                    int yEnd = (int)Math.Round(endY);

                    // Рисуем сплошной отрезок (он сам использует ThickLine_СheckBox)
                    DrawLineWithAlgorithm(xStart, yStart, xEnd, yEnd, color);
                }

                currentPos += segmentLength;
                draw = !draw; // Переключаем между рисованием и пропуском
            }
        }

        private void InitializeLineDrawingComponents()
        {
            // Настройка NumericUpDown для шага пунктира
            numericUpDownDashStep.Minimum = 2;
            numericUpDownDashStep.Maximum = 20;
            numericUpDownDashStep.Value = 5;
            numericUpDownDashStep.ValueChanged += NumericUpDownDashStep_ValueChanged;

            // Настройка ComboBox для типа линии
            comboBoxLineType.Items.Add("Сплошная");
            comboBoxLineType.Items.Add("Пунктирная");
            comboBoxLineType.SelectedIndex = 0;
            comboBoxLineType.SelectedIndexChanged += ComboBoxLineType_SelectedIndexChanged;

            // Настройка кнопки рисования линии
            buttonDrawLine.Click += ButtonDrawLine_Click;

            // Изначально отключаем настройку шага пунктира
            numericUpDownDashStep.Enabled = false;
        }

        // Обработчик изменения шага пунктира
        private void NumericUpDownDashStep_ValueChanged(object sender, EventArgs e)
        {
            dashStep = (int)numericUpDownDashStep.Value;
        }

        // Обработчик изменения типа линии
        private void ComboBoxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            isDashed = (comboBoxLineType.SelectedIndex == 1);
            // Если выбран пунктир, включаем NumericUpDown для шага
            numericUpDownDashStep.Enabled = isDashed;
        }
        // Обработчик рисования отрезка
        private void ButtonDrawLine_Click(object sender, EventArgs e)
        {
            try
            {
                // Считываем координаты из TextBox
                int x1 = Convert.ToInt32(textBoxX1.Text);
                int y1 = Convert.ToInt32(textBoxY1.Text);
                int x2 = Convert.ToInt32(textBoxX2.Text);
                int y2 = Convert.ToInt32(textBoxY2.Text);

                // Создаем bitmap если его нет
                if (myBitmap == null)
                    myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
                // Толщина определяется автоматически через ThickLine_СheckBox
                DrawLineWithStyle(x1, y1, x2, y2, currentBorderColor, isDashed, dashStep);

                // Обновляем PictureBox
                PictureBox.Image = myBitmap;
                PictureBox.Refresh();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения координат!",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Filling_RadioButton.Checked)
                return;

            myBitmap = PictureBox.Image as Bitmap;

            if (myBitmap == null)
            {
                MessageBox.Show("Сначала нарисуйте замкнутый контур.");
                return;
            }

            Color startColor = myBitmap.GetPixel(e.X, e.Y);

            if (startColor.ToArgb() == currentBorderColor.ToArgb() ||
                startColor.ToArgb() == currentFillColor.ToArgb())
                return;

            FloodFill(e.X, e.Y, startColor);

            PictureBox.Image = myBitmap;
            PictureBox.Refresh();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (CDA_RadioButton.Checked == true || SimpleCutting_RadioButton.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
        }

        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            double dx = xEnd - xStart;
            double dy = yEnd - yStart;

            int numberNodes = (int)Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (numberNodes == 0)
            {
                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(xStart, yStart, currentBorderColor);
                else
                    DrawPixel(xStart, yStart, currentBorderColor);

                return;
            }

            double xOutput = xStart;
            double yOutput = yStart;

            double xStep = dx / numberNodes;
            double yStep = dy / numberNodes;

            for (int i = 0; i <= numberNodes; i++)
            {
                int x = (int)Math.Round(xOutput);
                int y = (int)Math.Round(yOutput);

                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(x, y, currentBorderColor);
                else
                    DrawPixel(x, y, currentBorderColor);

                xOutput += xStep;
                yOutput += yStep;
            }
        }

        // Алгоритм Брезенхема
        private void BresenhamLine(int x1, int y1, int x2, int y2, Color color)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;
            int err = dx - dy;
            int x = x1, y = y1;

            while (true)
            {
                if (ThickLine_СheckBox.Checked)
                    DrawThickPixel(x, y, color);
                else
                    DrawPixel(x, y, color);

                if (x == x2 && y == y2) break;

                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x += sx; }
                if (e2 < dx) { err += dx; y += sy; }
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (CDA_RadioButton.Checked == true)
            {
                if (myBitmap == null)
                    myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

                CDA(xn, yn, e.X, e.Y);

                PictureBox.Image = myBitmap;
                PictureBox.Refresh();
            }
            else if (SimpleCutting_RadioButton.Checked == true)
            {
                clipStart = new Point(xn, yn);
                clipEnd = new Point(e.X, e.Y);
                clipLineDefined = true;

                DrawClipScene();
            }
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            PictureBox.Image = null;
            myBitmap = null;
            clipLineDefined = false;
        }

        private void ColorSelection_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            if (CDA_RadioButton.Checked)
            {
                if (colorDialog1.Color.ToArgb() == currentFillColor.ToArgb())
                {
                    MessageBox.Show("Цвет границы не должен совпадать с цветом заливки.");
                    return;
                }

                currentBorderColor = colorDialog1.Color;
            }
            else if (Filling_RadioButton.Checked)
            {
                if (colorDialog1.Color.ToArgb() == currentBorderColor.ToArgb())
                {
                    MessageBox.Show("Цвет заливки не должен совпадать с цветом границы.");
                    return;
                }

                currentFillColor = colorDialog1.Color;
            }
        }

        // Заливка с затравкой (рекурсивная)
        private void FloodFill(int x1, int y1, Color targetColor)
        {
            if (myBitmap == null) return;

            if (x1 < 0 || x1 >= myBitmap.Width || y1 < 0 || y1 >= myBitmap.Height)
                return;

            Color oldPixelColor = myBitmap.GetPixel(x1, y1);

            if (oldPixelColor.ToArgb() != targetColor.ToArgb())
                return;

            myBitmap.SetPixel(x1, y1, currentFillColor);

            FloodFill(x1 + 1, y1, targetColor);
            FloodFill(x1 - 1, y1, targetColor);
            FloodFill(x1, y1 + 1, targetColor);
            FloodFill(x1, y1 - 1, targetColor);
        }


        private async void Make_Button_Click(object sender, EventArgs e)
        {
            if (CDA_RadioButton.Checked)
            {
                myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

                CDA(10, 10, 10, 110);
                CDA(10, 10, 110, 10);
                CDA(10, 110, 110, 110);
                CDA(110, 10, 110, 110);

                CDA(150, 10, 150, 200);
                CDA(250, 50, 150, 200);
                CDA(150, 10, 250, 150);

                PictureBox.Image = myBitmap;
                PictureBox.Refresh();
            }
            else if (Filling_RadioButton.Checked)
            {
                myBitmap = PictureBox.Image as Bitmap;

                if (myBitmap == null)
                {
                    MessageBox.Show("Сначала нужно построить контур.");
                    return;
                }

                xn = 160;
                yn = 40;
                Color targetColor = myBitmap.GetPixel(xn, yn);
                FloodFill(xn, yn, targetColor);

                PictureBox.Image = myBitmap;
                PictureBox.Refresh();
            }
            else if (Contour_RadioButton.Checked)
            {
                myBitmap = PictureBox.Image as Bitmap;

                if (myBitmap == null)
                {
                    MessageBox.Show("Сначала нужно построить контур.");
                    return;
                }

                await TraceComplexContour();
            }
            else if (SimpleCutting_RadioButton.Checked)
            {
                Point p1 = clipStart;
                Point p2 = clipEnd;

                DrawClipScene();

                if (clipLineDefined == true)
                {
                    if (SimpleClip(ref p1, ref p2))
                    {
                        Graphics g = Graphics.FromImage(myBitmap);
                        Pen myPen = new Pen(Color.Red, 2);
                        g.DrawLine(myPen, p1, p2);

                        PictureBox.Image = myBitmap;
                        PictureBox.Refresh();
                    }
                }
            }
        }

        private void DrawPixel(int x, int y, Color color)
        {
            if (myBitmap == null) return;

            if (x >= 0 && x < myBitmap.Width &&
                y >= 0 && y < myBitmap.Height)
            {
                myBitmap.SetPixel(x, y, color);
            }
        }

        private void DrawThickPixel(int x, int y, Color color)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    DrawPixel(x + dx, y + dy, color);
                }
            }
        }

        private bool IsContourPixel(int x, int y)
        {
            if (myBitmap == null) return false;

            if (x < 0 || x >= myBitmap.Width || y < 0 || y >= myBitmap.Height)
                return false;

            return myBitmap.GetPixel(x, y).ToArgb() == currentBorderColor.ToArgb();
        }

        private Point FindFirstContourPixel()
        {
            for (int y = 0; y < myBitmap.Height; y++)
            {
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    if (IsContourPixel(x, y))
                        return new Point(x, y);
                }
            }

            return new Point(-1, -1);
        }

        private List<Point> GetNeighbors(int x, int y, bool[,] visited)
        {
            List<Point> neighbors = new List<Point>();

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < myBitmap.Width &&
                        ny >= 0 && ny < myBitmap.Height &&
                        !visited[nx, ny] &&
                        IsContourPixel(nx, ny))
                    {
                        neighbors.Add(new Point(nx, ny));
                    }
                }
            }

            return neighbors;
        }

        private async Task TraceComplexContour()
        {
            if (myBitmap == null)
            {
                MessageBox.Show("Сначала нарисуйте контур.");
                return;
            }

            Point start = FindFirstContourPixel();

            if (start.X == -1)
            {
                MessageBox.Show("Контур не найден.");
                return;
            }

            bool[,] visited = new bool[myBitmap.Width, myBitmap.Height];
            Stack<Point> stack = new Stack<Point>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                Point p = stack.Pop();

                if (visited[p.X, p.Y])
                    continue;

                visited[p.X, p.Y] = true;

                myBitmap.SetPixel(p.X, p.Y, contourTraceColor);

                PictureBox.Image = myBitmap;
                PictureBox.Refresh();

                await Task.Delay(10);

                List<Point> neighbors = GetNeighbors(p.X, p.Y, visited);

                for (int i = 0; i < neighbors.Count; i++)
                {
                    stack.Push(neighbors[i]);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonBresenham_CheckedChanged(object sender, EventArgs e)
        {
            useBresenham = radioButtonBresenham.Checked;
        }

        /// <summary>
        /// Рисует сцену для простого двумерного отсечения:
        /// окно отсечения и исходный отрезок.
        /// </summary>
        private void DrawClipScene()
        {
            myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

            Graphics g = Graphics.FromImage(myBitmap);

            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, clipRectangle);
            g.DrawLine(Pens.Gray, clipStart, clipEnd);

            PictureBox.Image = myBitmap;
            PictureBox.Refresh();
        }

        /// <summary>
        /// Проверяет, находится ли точка внутри окна отсечения.
        /// </summary>
        /// <param name="x">Координата X точки.</param>
        /// <param name="y">Координата Y точки.</param>
        /// <returns>
        /// true, если точка находится внутри окна отсечения;
        /// иначе false.
        /// </returns>
        private bool PointInsideRectangle(double x, double y)
        {
            return x >= clipRectangle.Left && x <= clipRectangle.Right &&
                   y >= clipRectangle.Top && y <= clipRectangle.Bottom;
        }

        /// <summary>
        /// Вычисляет пересечение отрезка с левой стороной окна отсечения
        /// и добавляет найденную точку в список.
        /// </summary>
        /// <param name="x1">X первой точки отрезка.</param>
        /// <param name="y1">Y первой точки отрезка.</param>
        /// <param name="x2">X второй точки отрезка.</param>
        /// <param name="y2">Y второй точки отрезка.</param>
        /// <param name="xl">Левая граница окна.</param>
        /// <param name="yv">Верхняя граница окна.</param>
        /// <param name="yn">Нижняя граница окна.</param>
        /// <param name="points">Список найденных точек пересечения.</param>
        private void AddIntersectionWithLeftSide(double x1, double y1, double x2, double y2, double xl, double yv, double yn, List<PointF> points)
        {
            if (x1 == x2) return;

            double t = (xl - x1) / (x2 - x1);
            if (t < 0 || t > 1) return;

            double m = (y2 - y1) / (x2 - x1);
            double y = m * (xl - x1) + y1;

            if (y >= yv && y <= yn)
                points.Add(new PointF((float)xl, (float)y));
        }

        /// <summary>
        /// Вычисляет пересечение отрезка с правой стороной окна отсечения
        /// и добавляет найденную точку в список.
        /// </summary>
        /// <param name="x1">X первой точки отрезка.</param>
        /// <param name="y1">Y первой точки отрезка.</param>
        /// <param name="x2">X второй точки отрезка.</param>
        /// <param name="y2">Y второй точки отрезка.</param>
        /// <param name="xp">Правая граница окна.</param>
        /// <param name="yv">Верхняя граница окна.</param>
        /// <param name="yn">Нижняя граница окна.</param>
        /// <param name="points">Список найденных точек пересечения.</param>
        private void AddIntersectionWithRightSide(double x1, double y1, double x2, double y2, double xp, double yv, double yn, List<PointF> points)
        {
            if (x1 == x2) return;

            double t = (xp - x1) / (x2 - x1);
            if (t < 0 || t > 1) return;

            double m = (y2 - y1) / (x2 - x1);
            double y = m * (xp - x1) + y1;

            if (y >= yv && y <= yn)
                points.Add(new PointF((float)xp, (float)y));
        }

        /// <summary>
        /// Вычисляет пересечение отрезка с верхней стороной окна отсечения
        /// и добавляет найденную точку в список.
        /// </summary>
        /// <param name="x1">X первой точки отрезка.</param>
        /// <param name="y1">Y первой точки отрезка.</param>
        /// <param name="x2">X второй точки отрезка.</param>
        /// <param name="y2">Y второй точки отрезка.</param>
        /// <param name="yv">Верхняя граница окна.</param>
        /// <param name="xl">Левая граница окна.</param>
        /// <param name="xp">Правая граница окна.</param>
        /// <param name="points">Список найденных точек пересечения.</param>
        private void AddIntersectionWithTopSide(double x1, double y1, double x2, double y2, double yv, double xl, double xp, List<PointF> points)
        {
            if (y1 == y2) return;

            double t = (yv - y1) / (y2 - y1);
            if (t < 0 || t > 1) return;

            double m = (y2 - y1) / (x2 - x1);
            double x = x1 + (yv - y1) / m;

            if (x >= xl && x <= xp)
                points.Add(new PointF((float)x, (float)yv));
        }

        /// <summary>
        /// Вычисляет пересечение отрезка с нижней стороной окна отсечения
        /// и добавляет найденную точку в список.
        /// </summary>
        /// <param name="x1">X первой точки отрезка.</param>
        /// <param name="y1">Y первой точки отрезка.</param>
        /// <param name="x2">X второй точки отрезка.</param>
        /// <param name="y2">Y второй точки отрезка.</param>
        /// <param name="yn">Нижняя граница окна.</param>
        /// <param name="xl">Левая граница окна.</param>
        /// <param name="xp">Правая граница окна.</param>
        /// <param name="points">Список найденных точек пересечения.</param>
        private void AddIntersectionWithBottomSide(double x1, double y1, double x2, double y2, double yn, double xl, double xp, List<PointF> points)
        {
            if (y1 == y2) return;

            double t = (yn - y1) / (y2 - y1);
            if (t < 0 || t > 1) return;

            double m = (y2 - y1) / (x2 - x1);
            double x = x1 + (yn - y1) / m;

            if (x >= xl && x <= xp)
                points.Add(new PointF((float)x, (float)yn));
        }

        /// <summary>
        /// Выполняет простое двумерное отсечение отрезка прямоугольным окном.
        /// </summary>
        /// <param name="p1">Первая точка отрезка. После выполнения содержит первую точку видимой части.</param>
        /// <param name="p2">Вторая точка отрезка. После выполнения содержит вторую точку видимой части.</param>
        /// <returns>
        /// true, если отрезок полностью или частично видим;
        /// false, если отрезок полностью невидим.
        /// </returns>
        private bool SimpleClip(ref Point p1, ref Point p2)
        {
            double x1 = p1.X, y1 = p1.Y;
            double x2 = p2.X, y2 = p2.Y;

            double xl = clipRectangle.Left;
            double xp = clipRectangle.Right;
            double yv = clipRectangle.Top;
            double yn = clipRectangle.Bottom;

            if (PointInsideRectangle(x1, y1) && PointInsideRectangle(x2, y2))
                return true;

            if (x1 < xl && x2 < xl) return false;
            if (x1 > xp && x2 > xp) return false;
            if (y1 < yv && y2 < yv) return false;
            if (y1 > yn && y2 > yn) return false;

            List<PointF> points = new List<PointF>();

            if (PointInsideRectangle(x1, y1))
                points.Add(new PointF((float)x1, (float)y1));

            if (PointInsideRectangle(x2, y2))
                points.Add(new PointF((float)x2, (float)y2));

            AddIntersectionWithLeftSide(x1, y1, x2, y2, xl, yv, yn, points);
            AddIntersectionWithRightSide(x1, y1, x2, y2, xp, yv, yn, points);
            AddIntersectionWithTopSide(x1, y1, x2, y2, yv, xl, xp, points);
            AddIntersectionWithBottomSide(x1, y1, x2, y2, yn, xl, xp, points);

            p1 = new Point((int)points[0].X, (int)points[0].Y);
            p2 = new Point((int)points[1].X, (int)points[1].Y);

            return true;
        }
    }
}
