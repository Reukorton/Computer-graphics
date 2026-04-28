using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LR1T2
{
    public partial class Train : Form
    {
        private System.Windows.Forms.Timer trainTimer;

        private int backgroundShift = 0;
        private double wheelAngle = 0;

        public Train()
        {
            InitializeComponent();

            this.Text = "Индивидуальное задание 13 — поезд";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;

            trainTimer = new System.Windows.Forms.Timer();
            trainTimer.Interval = 35;
            trainTimer.Tick += TrainTimer_Tick;

            this.Load += Train_Load;
            this.FormClosed += Train_FormClosed;
            this.Resize += Train_Resize;
            this.KeyDown += Train_KeyDown;
        }

        private void Train_Load(object sender, EventArgs e)
        {
            DrawScene();
            trainTimer.Start();
        }

        private void Train_Resize(object sender, EventArgs e)
        {
            DrawScene();
        }

        private void Train_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (trainTimer.Enabled)
                    trainTimer.Stop();
                else
                    trainTimer.Start();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void TrainTimer_Tick(object sender, EventArgs e)
        {
            backgroundShift += 6;

            // Локомотив смотрит влево, фон едет вправо.
            // Колеса вращаем в обратную сторону, чтобы визуально совпадало с движением.
            wheelAngle -= 0.22;

            if (backgroundShift > 900000)
                backgroundShift = 0;

            DrawScene();
        }

        private void Train_FormClosed(object sender, FormClosedEventArgs e)
        {
            trainTimer.Stop();
            trainTimer.Dispose();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private int PositiveMod(int value, int modulus)
        {
            int result = value % modulus;

            if (result < 0)
                result += modulus;

            return result;
        }

        private void DrawScene()
        {
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0)
                return;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int w = pictureBox1.Width;
                int h = pictureBox1.Height;

                int groundY = h - 105;
                int railY = h - 70;

                DrawBackground(g, w, h, groundY);
                DrawMovingTrees(g, w, groundY);
                DrawRails(g, w, railY);
                DrawTrain(g, w, railY);
            }

            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = bmp;

            if (oldImage != null)
                oldImage.Dispose();
        }

        private void DrawBackground(Graphics g, int w, int h, int groundY)
        {
            using (SolidBrush skyBrush = new SolidBrush(Color.FromArgb(220, 240, 255)))
            using (SolidBrush groundBrush = new SolidBrush(Color.FromArgb(180, 220, 165)))
            using (SolidBrush sunBrush = new SolidBrush(Color.FromArgb(255, 220, 90)))
            {
                g.FillRectangle(skyBrush, 0, 0, w, h);
                g.FillRectangle(groundBrush, 0, groundY, w, h - groundY);
                g.FillEllipse(sunBrush, w - 100, 35, 60, 60);
            }
        }

        private void DrawMovingTrees(Graphics g, int w, int groundY)
        {
            int spacing = 90;

            int firstIndex = (int)Math.Floor((-backgroundShift - spacing) / (double)spacing);
            int lastIndex = (int)Math.Ceiling((w - backgroundShift + spacing) / (double)spacing);

            for (int treeIndex = firstIndex; treeIndex <= lastIndex; treeIndex++)
            {
                int x = treeIndex * spacing + backgroundShift;

                int treeType = PositiveMod(treeIndex, 3);
                int size = 35 + PositiveMod(treeIndex * 17, 25);

                DrawTree(g, x, groundY, size, treeType);
            }
        }

        private void DrawTree(Graphics g, int x, int groundY, int size, int type)
        {
            using (SolidBrush trunkBrush = new SolidBrush(Color.SaddleBrown))
            using (SolidBrush crownBrush = new SolidBrush(Color.FromArgb(45, 130, 65)))
            using (Pen crownPen = new Pen(Color.DarkGreen, 1))
            {
                int trunkWidth = Math.Max(5, size / 6);
                int trunkHeight = size;

                g.FillRectangle(
                    trunkBrush,
                    x - trunkWidth / 2,
                    groundY - trunkHeight,
                    trunkWidth,
                    trunkHeight
                );

                if (type == 0)
                {
                    Point[] crown =
                    {
                        new Point(x, groundY - trunkHeight - size),
                        new Point(x - size / 2, groundY - trunkHeight + 5),
                        new Point(x + size / 2, groundY - trunkHeight + 5)
                    };

                    g.FillPolygon(crownBrush, crown);
                    g.DrawPolygon(crownPen, crown);
                }
                else if (type == 1)
                {
                    g.FillEllipse(crownBrush, x - size / 2, groundY - trunkHeight - size, size, size);
                    g.DrawEllipse(crownPen, x - size / 2, groundY - trunkHeight - size, size, size);
                }
                else
                {
                    g.FillEllipse(crownBrush, x - size / 2, groundY - trunkHeight - size, size, size);
                    g.FillEllipse(crownBrush, x - size / 3, groundY - trunkHeight - size - 12, size, size);
                    g.FillEllipse(crownBrush, x - size / 4, groundY - trunkHeight - size + 12, size, size);
                }
            }
        }

        private void DrawRails(Graphics g, int w, int railY)
        {
            using (Pen railPen = new Pen(Color.DimGray, 4))
            using (SolidBrush sleeperBrush = new SolidBrush(Color.SaddleBrown))
            {
                int sleeperSpacing = 42;

                int firstIndex = (int)Math.Floor((-backgroundShift - sleeperSpacing) / (double)sleeperSpacing);
                int lastIndex = (int)Math.Ceiling((w - backgroundShift + sleeperSpacing) / (double)sleeperSpacing);

                for (int sleeperIndex = firstIndex; sleeperIndex <= lastIndex; sleeperIndex++)
                {
                    int x = sleeperIndex * sleeperSpacing + backgroundShift;
                    g.FillRectangle(sleeperBrush, x, railY - 18, 28, 36);
                }

                g.DrawLine(railPen, 0, railY - 9, w, railY - 9);
                g.DrawLine(railPen, 0, railY + 9, w, railY + 9);
            }
        }

        private void DrawTrain(Graphics g, int w, int railY)
        {
            int startX = w / 2 - 230;

            if (startX < 20)
                startX = 20;

            int wheelY = railY - 18;
            int bodyBottom = wheelY - 18;

            int locomotiveX = startX;
            int locomotiveTop = bodyBottom - 65;

            int wagonX = locomotiveX + 180;
            int wagonTop = bodyBottom - 58;

            DrawLocomotive(g, locomotiveX, locomotiveTop, bodyBottom, wheelY);
            DrawWagon(g, wagonX, wagonTop, bodyBottom, wheelY);

            using (Pen connectorPen = new Pen(Color.Black, 3))
            {
                g.DrawLine(connectorPen, locomotiveX + 168, bodyBottom - 15, wagonX, bodyBottom - 15);
            }
        }

        private void DrawLocomotive(Graphics g, int x, int top, int bottom, int wheelY)
        {
            using (SolidBrush bodyBrush = new SolidBrush(Color.FromArgb(70, 90, 120)))
            using (SolidBrush cabinBrush = new SolidBrush(Color.FromArgb(90, 115, 150)))
            using (SolidBrush windowBrush = new SolidBrush(Color.LightCyan))
            using (SolidBrush chimneyBrush = new SolidBrush(Color.FromArgb(55, 55, 55)))
            using (Pen outlinePen = new Pen(Color.Black, 2))
            {
                // Основная часть локомотива
                g.FillRectangle(bodyBrush, x + 20, top + 25, 110, bottom - top - 25);
                g.DrawRectangle(outlinePen, x + 20, top + 25, 110, bottom - top - 25);

                // Кабина сзади
                g.FillRectangle(cabinBrush, x + 100, top, 60, bottom - top);
                g.DrawRectangle(outlinePen, x + 100, top, 60, bottom - top);

                // Окно кабины
                g.FillRectangle(windowBrush, x + 112, top + 12, 30, 24);
                g.DrawRectangle(outlinePen, x + 112, top + 12, 30, 24);

                // Труба спереди
                g.FillRectangle(chimneyBrush, x + 38, top + 5, 22, 35);
                g.DrawRectangle(outlinePen, x + 38, top + 5, 22, 35);

                g.FillRectangle(chimneyBrush, x + 32, top, 34, 10);
                g.DrawRectangle(outlinePen, x + 32, top, 34, 10);

                // Нос локомотива, чтобы направление было понятнее
                Point[] front =
                {
                    new Point(x + 20, bottom),
                    new Point(x, bottom - 18),
                    new Point(x + 20, bottom - 36)
                };

                g.FillPolygon(bodyBrush, front);
                g.DrawPolygon(outlinePen, front);
            }

            int r = 18;
            int wheel1X = x + 50;
            int wheel2X = x + 120;

            DrawWheel(g, wheel1X, wheelY, r, wheelAngle);
            DrawWheel(g, wheel2X, wheelY, r, wheelAngle);
            DrawRod(g, wheel1X, wheelY, wheel2X, wheelY, r, wheelAngle);
        }

        private void DrawWagon(Graphics g, int x, int top, int bottom, int wheelY)
        {
            using (SolidBrush bodyBrush = new SolidBrush(Color.FromArgb(160, 80, 60)))
            using (SolidBrush roofBrush = new SolidBrush(Color.FromArgb(100, 55, 45)))
            using (Pen outlinePen = new Pen(Color.Black, 2))
            {
                g.FillRectangle(bodyBrush, x, top, 230, bottom - top);
                g.DrawRectangle(outlinePen, x, top, 230, bottom - top);

                g.FillRectangle(roofBrush, x - 5, top - 12, 240, 14);
                g.DrawRectangle(outlinePen, x - 5, top - 12, 240, 14);
            }

            for (int i = 0; i < 4; i++)
            {
                Rectangle window = new Rectangle(x + 20 + i * 50, top + 13, 34, 28);
                DrawMovingWindow(g, window, i);
            }

            int r = 15;
            int wheel1X = x + 55;
            int wheel2X = x + 175;

            DrawWheel(g, wheel1X, wheelY, r, wheelAngle);
            DrawWheel(g, wheel2X, wheelY, r, wheelAngle);
            DrawRod(g, wheel1X, wheelY, wheel2X, wheelY, r, wheelAngle);
        }

        private void DrawMovingWindow(Graphics g, Rectangle window, int index)
        {
            using (SolidBrush skyBrush = new SolidBrush(Color.FromArgb(205, 235, 255)))
            using (Pen borderPen = new Pen(Color.Black, 2))
            {
                g.FillRectangle(skyBrush, window);
                g.DrawRectangle(borderPen, window);
            }

            GraphicsState state = g.Save();
            g.SetClip(window);

            int localGroundY = window.Bottom - 4;
            int spacing = 24;

            int firstIndex = (int)Math.Floor((window.Left - backgroundShift - spacing) / (double)spacing);
            int lastIndex = (int)Math.Ceiling((window.Right - backgroundShift + spacing) / (double)spacing);

            for (int treeIndex = firstIndex; treeIndex <= lastIndex; treeIndex++)
            {
                int x = treeIndex * spacing + backgroundShift;

                int treeType = PositiveMod(treeIndex + index, 3);

                DrawSmallTree(g, x, localGroundY, treeType);
            }

            g.Restore(state);

            using (Pen borderPen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(borderPen, window);
            }
        }

        private void DrawSmallTree(Graphics g, int x, int groundY, int type)
        {
            using (SolidBrush trunkBrush = new SolidBrush(Color.SaddleBrown))
            using (SolidBrush crownBrush = new SolidBrush(Color.ForestGreen))
            {
                g.FillRectangle(trunkBrush, x, groundY - 10, 3, 10);

                if (type == 0)
                {
                    Point[] crown =
                    {
                        new Point(x + 1, groundY - 24),
                        new Point(x - 7, groundY - 10),
                        new Point(x + 9, groundY - 10)
                    };

                    g.FillPolygon(crownBrush, crown);
                }
                else if (type == 1)
                {
                    g.FillEllipse(crownBrush, x - 5, groundY - 22, 14, 14);
                }
                else
                {
                    g.FillEllipse(crownBrush, x - 6, groundY - 20, 12, 12);
                    g.FillEllipse(crownBrush, x - 1, groundY - 24, 12, 12);
                }
            }
        }

        private void DrawWheel(Graphics g, int cx, int cy, int r, double angle)
        {
            using (SolidBrush wheelBrush = new SolidBrush(Color.FromArgb(35, 35, 35)))
            using (SolidBrush centerBrush = new SolidBrush(Color.LightGray))
            using (Pen wheelPen = new Pen(Color.Black, 2))
            using (Pen spokePen = new Pen(Color.LightGray, 2))
            {
                g.FillEllipse(wheelBrush, cx - r, cy - r, r * 2, r * 2);
                g.DrawEllipse(wheelPen, cx - r, cy - r, r * 2, r * 2);

                for (int i = 0; i < 6; i++)
                {
                    double a = angle + i * Math.PI / 3.0;

                    int x2 = cx + (int)(Math.Cos(a) * r);
                    int y2 = cy + (int)(Math.Sin(a) * r);

                    g.DrawLine(spokePen, cx, cy, x2, y2);
                }

                g.FillEllipse(centerBrush, cx - 4, cy - 4, 8, 8);
                g.DrawEllipse(wheelPen, cx - 4, cy - 4, 8, 8);
            }
        }

        private void DrawRod(Graphics g, int x1, int y1, int x2, int y2, int r, double angle)
        {
            Point p1 = GetCrankPoint(x1, y1, r, angle);
            Point p2 = GetCrankPoint(x2, y2, r, angle);

            using (Pen rodOutlinePen = new Pen(Color.Black, 5))
            using (Pen rodPen = new Pen(Color.Silver, 3))
            {
                g.DrawLine(rodOutlinePen, p1, p2);
                g.DrawLine(rodPen, p1, p2);
            }
        }

        private Point GetCrankPoint(int cx, int cy, int r, double angle)
        {
            int crankR = (int)(r * 0.65);

            return new Point(
                cx + (int)(Math.Cos(angle) * crankR),
                cy + (int)(Math.Sin(angle) * crankR)
            );
        }
    }
}