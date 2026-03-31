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

        public Form3()
        {
            InitializeComponent();
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
            if (CDA_RadioButton.Checked == true)
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

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CDA_RadioButton.Checked) return;

            if (myBitmap == null)
                myBitmap = new Bitmap(PictureBox.Width, PictureBox.Height);

            CDA(xn, yn, e.X, e.Y);

            PictureBox.Image = myBitmap;
            PictureBox.Refresh();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            PictureBox.Image = null;
            myBitmap = null;
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
    }
}
