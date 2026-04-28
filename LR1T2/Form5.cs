using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1T2
{
    /// <summary>
    /// Форма для отображения правильного треугольника и пятиугольника,
    /// вращающихся вокруг своих центров.
    /// </summary>
    public partial class Form5 : Form
    {
        /// <summary>
        /// Текущий угол поворота треугольника.
        /// </summary>
        double angleTriangle = 0;

        /// <summary>
        /// Текущий угол поворота пятиугольника.
        /// </summary>
        double anglePentagon = 0;

        /// <summary>
        /// Скорость вращения треугольника.
        /// Положительное значение задает одно направление вращения.
        /// </summary>
        double speedTriangle = 5;

        /// <summary>
        /// Скорость вращения пятиугольника.
        /// Отрицательное значение задает противоположное направление вращения.
        /// </summary>
        double speedPentagon = -5;

        /// <summary>
        /// Координаты центра треугольника.
        /// </summary>
        int triangleX, triangleY;

        /// <summary>
        /// Координаты центра пятиугольника.
        /// </summary>
        int pentagonX, pentagonY;

        /// <summary>
        /// Радиус окружности, на которой располагаются вершины треугольника.
        /// </summary>
        int triangleRadius = 60;

        /// <summary>
        /// Радиус окружности, на которой располагаются вершины пятиугольника.
        /// </summary>
        int pentagonRadius = 60;

        /// <summary>
        /// Конструктор формы.
        /// Включает обработку нажатий клавиш на уровне формы.
        /// </summary>
        public Form5()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        /// <summary>
        /// Обработчик загрузки формы.
        /// Задает начальные координаты центров фигур и запускает таймер.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Form5_Load(object sender, EventArgs e)
        {
            triangleX = pictureBox1.Width / 4;
            triangleY = pictureBox1.Height / 2;

            pentagonX = pictureBox1.Width * 3 / 4;
            pentagonY = pictureBox1.Height / 2;

            timer1.Interval = 100;
            timer1.Start();
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
        /// Рисует правильный многоугольник по заданному центру, радиусу,
        /// количеству сторон, углу поворота и цвету.
        /// </summary>
        /// <param name="xCenter">Координата X центра фигуры.</param>
        /// <param name="yCenter">Координата Y центра фигуры.</param>
        /// <param name="radius">Радиус окружности, на которой лежат вершины фигуры.</param>
        /// <param name="n">Количество сторон многоугольника.</param>
        /// <param name="angle">Угол поворота фигуры.</param>
        /// <param name="color">Цвет линии фигуры.</param>
        private void DrawPolygon(int xCenter, int yCenter, int radius, int n, double angle, Color color)
        {
            Point[] p = new Point[n];

            for (int i = 0; i < n; i++)
            {
                double a = angle * Math.PI / 180 + 2 * Math.PI * i / n;

                int x = xCenter + (int)(radius * Math.Cos(a));
                int y = yCenter + (int)(radius * Math.Sin(a));

                p[i] = new Point(x, y);
            }

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen myPen = new Pen(color, 2);

            g.DrawPolygon(myPen, p);

            myPen.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// Очищает поле рисования и выводит на экран треугольник и пятиугольник.
        /// </summary>
        private void DrawFigures()
        {
            ImageClear();

            DrawPolygon(triangleX, triangleY, triangleRadius, 3, angleTriangle, Color.Blue);
            DrawPolygon(pentagonX, pentagonY, pentagonRadius, 5, anglePentagon, Color.Red);
        }

        /// <summary>
        /// Обработчик события таймера.
        /// Изменяет углы поворота фигур и перерисовывает изображение.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            angleTriangle += speedTriangle;
            anglePentagon += speedPentagon;

            DrawFigures();
        }

        /// <summary>
        /// Обработчик нажатия клавиш.
        /// Позволяет отдельно управлять скоростью и направлением вращения
        /// треугольника и пятиугольника.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события клавиатуры.</param>
        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            // ТРЕУГОЛЬНИК
            if (e.KeyCode == Keys.W)
            {
                speedTriangle++;
            }

            if (e.KeyCode == Keys.S)
            {
                speedTriangle--;
            }

            if (e.KeyCode == Keys.A)
            {
                speedTriangle = -Math.Abs(speedTriangle);
            }

            if (e.KeyCode == Keys.D)
            {
                speedTriangle = Math.Abs(speedTriangle);
            }

            // ПЯТИУГОЛЬНИК
            if (e.KeyCode == Keys.I)
            {
                speedPentagon++;
            }

            if (e.KeyCode == Keys.K)
            {
                speedPentagon--;
            }

            if (e.KeyCode == Keys.J)
            {
                speedPentagon = -Math.Abs(speedPentagon);
            }

            if (e.KeyCode == Keys.L)
            {
                speedPentagon = Math.Abs(speedPentagon);
            }
        }
    }
}