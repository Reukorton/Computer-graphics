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

namespace LR1T2
{
    public partial class Form4 : Form
    {
        int[,] kv = new int[5, 3]; // матрица тела
        int currentFigure = 3; // выбранная фигура
        int[,] osi = new int[4, 3]; // матрица координат осей
        int[,] matr_sdv = new int[3, 3]; // матрица преобразования

        int k, l; // элементы матрицы сдвига
        bool f = true; // переменная для запуска и остановки движения
        double angle = 0; // угол поворота
        double scale = 1; // масштаб

        int reflectX = 1; // отражение по X
        int reflectY = 1; // отражение по Y

        int animationMode = 1;
        // 1 - смещение
        // 2 - поворот
        // 3 - масштабирование: увеличить
        // 4 - масштабирование: уменьшить
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
        }

        // инициализация матрицы тела
        private void Init_figure()
        {
            if (currentFigure == 3)
            {
                // Вариант 3
                kv[0, 0] = -65; kv[0, 1] = -100; kv[0, 2] = 1; // верхняя левая
                kv[1, 0] = 65; kv[1, 1] = -100; kv[1, 2] = 1; // верхняя правая
                kv[2, 0] = -65; kv[2, 1] = 110; kv[2, 2] = 1; // нижняя левая
                kv[3, 0] = 95; kv[3, 1] = 80; kv[3, 2] = 1; // нижняя правая
            }

            if (currentFigure == 4)
            {
                // Вариант 4
                kv[0, 0] = -70; kv[0, 1] = -100; kv[0, 2] = 1;
                kv[1, 0] = 80; kv[1, 1] = -70; kv[1, 2] = 1;
                kv[2, 0] = 10; kv[2, 1] = 0; kv[2, 2] = 1;
                kv[3, 0] = 80; kv[3, 1] = 70; kv[3, 2] = 1;
                kv[4, 0] = -70; kv[4, 1] = 100; kv[4, 2] = 1;
            }

            if (currentFigure == 11)
            {
                // Вариант 11
                kv[0, 0] = 0; kv[0, 1] = -90; kv[0, 2] = 1;
                kv[1, 0] = 90; kv[1, 1] = 0; kv[1, 2] = 1;
                kv[2, 0] = 0; kv[2, 1] = 90; kv[2, 2] = 1;
                kv[3, 0] = -90; kv[3, 1] = 0; kv[3, 2] = 1;
                kv[4, 0] = 0; kv[4, 1] = 0; kv[4, 2] = 1;
            }

            if (currentFigure == 13)
            {
                // Вариант 13
                kv[0, 0] = -80; kv[0, 1] = -90; kv[0, 2] = 1;
                kv[1, 0] = -80; kv[1, 1] = 70; kv[1, 2] = 1;
                kv[2, 0] = 40; kv[2, 1] = 100; kv[2, 2] = 1;
                kv[3, 0] = 130; kv[3, 1] = 45; kv[3, 2] = 1;
                kv[4, 0] = 0; kv[4, 1] = 0; kv[4, 2] = 1;
            }
        }

        // инициализация матрицы сдвига
        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        // инициализация матрицы осей
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }

        // умножение матриц
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
        // перевод int матрицы в double
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

        // умножение матриц double
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

        // матрица сдвига
        private double[,] Init_matr_sdv_double(double k1, double l1)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = 1; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = 1; m[1, 2] = 0;
            m[2, 0] = k1; m[2, 1] = l1; m[2, 2] = 1;

            return m;
        }

        // матрица масштабирования
        private double[,] Init_matr_scale(double s)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = s; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = s; m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        // матрица поворота
        private double[,] Init_matr_rotate(double angle)
        {
            double[,] m = new double[3, 3];

            double a = angle * Math.PI / 180;

            m[0, 0] = Math.Cos(a); m[0, 1] = Math.Sin(a); m[0, 2] = 0;
            m[1, 0] = -Math.Sin(a); m[1, 1] = Math.Cos(a); m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        // матрица отражения
        private double[,] Init_matr_reflect(int rx, int ry)
        {
            double[,] m = new double[3, 3];

            m[0, 0] = rx; m[0, 1] = 0; m[0, 2] = 0;
            m[1, 0] = 0; m[1, 1] = ry; m[1, 2] = 0;
            m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = 1;

            return m;
        }

        // рисование линии по double координатам
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

        // вывод фигуры на экран
        private void Draw_Kv()
        {
            ImageClear(); // очистка старого изображения фигуры

            Init_figure(); // инициализация матрицы тела

            double[,] kv1 = IntToDouble(kv);

            kv1 = Multiply_matr_double(kv1, Init_matr_scale(scale));
            kv1 = Multiply_matr_double(kv1, Init_matr_rotate(angle));
            kv1 = Multiply_matr_double(kv1, Init_matr_reflect(reflectX, reflectY));
            kv1 = Multiply_matr_double(kv1, Init_matr_sdv_double(k, l));

            Pen myPen = new Pen(Color.Blue, 2);

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            if (currentFigure == 3)
            {
                // Вариант 3
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 0, 3);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
            }

            if (currentFigure == 4)
            {
                // Вариант 4
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 4);
                DrawLineDouble(g, myPen, kv1, 4, 0);
            }

            if (currentFigure == 11)
            {
                // Вариант 11
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 0);
            }

            if (currentFigure == 13)
            {
                // Вариант 13
                DrawLineDouble(g, myPen, kv1, 0, 1);
                DrawLineDouble(g, myPen, kv1, 1, 2);
                DrawLineDouble(g, myPen, kv1, 2, 3);
                DrawLineDouble(g, myPen, kv1, 3, 0);
            }

            g.Dispose();
            myPen.Dispose();
        }

        // очистка поля рисования
        private void ImageClear()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(pictureBox1.BackColor);
            g.Dispose();
        }

        // вывод осей на экран
        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(k, l);

            int[,] osi1 = Multiply_matr(osi, matr_sdv);

            Pen myPen = new Pen(Color.Red, 1);

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем ось OX
            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);

            // рисуем ось OY
            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        // кнопка "Нарисовать оси"
        private void Draw_axes_Button_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Draw_osi();
        }

        // кнопка "Очистить"
        private void Сlear_Click(object sender, EventArgs e)
        {
            ImageClear();
        }

        // сдвиг вправо
        private void Shift_Right_Button_Click(object sender, EventArgs e)
        {
            k += 5;
            Draw_Kv();
        }

        // сдвиг влево
        private void Shift_Left_Button_Click(object sender, EventArgs e)
        {
            k -= 5;
            Draw_Kv();
        }

        // сдвиг вниз
        private void Shift_Down_Button_Click(object sender, EventArgs e)
        {
            l += 5;
            Draw_Kv();
        }

        // сдвиг вверх
        private void Shift_Up_Button_Click(object sender, EventArgs e)
        {
            {
                l -= 5;
                Draw_Kv();
            }
        }

        // непрерывное перемещение
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

        // обработчик таймера
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

        // фигура вариант 3
        private void Variant3_Button_Click(object sender, EventArgs e)
        {
            currentFigure = 3;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_Kv();
        }

        // фигура вариант 4 
        private void Variant4_Button_Click(object sender, EventArgs e)
        {
            currentFigure = 4;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_Kv();
        }

        // фигура вариант 11
        private void Variant11_Button_Click(object sender, EventArgs e)
        {
            currentFigure = 11;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_Kv();
        }

        // фигура вариант 13
        private void Variant13_Button_Click(object sender, EventArgs e)
        {
            currentFigure = 13;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_Kv();
        }

        // отражение относительно OX
        private void Reflect_OX_Button_Click(object sender, EventArgs e)
        {
            reflectY = -reflectY;
            Draw_Kv();
        }

        // отражение относительно OY
        private void Reflect_OY_Button_Click(object sender, EventArgs e)
        {
            reflectX = -reflectX;
            Draw_Kv();
        }

        // масштабирование: увеличить
        private void Scale_Up_Button_Click(object sender, EventArgs e)
        {
            scale *= 1.1;
            Draw_Kv();
        }

        // масштабирование: уменьшить
        private void Scale_Down_Button_Click(object sender, EventArgs e)
        {
            scale *= 0.9;
            Draw_Kv();
        }

        // поворот вправо
        private void Rotate_Right_Button_Click(object sender, EventArgs e)
        {
            angle += 10;
            Draw_Kv();
        }

        // поворот влево
        private void Rotate_Left_Button_Click(object sender, EventArgs e)
        {
            angle -= 10;
            Draw_Kv();
        }

        private void Continuous_Shift_Button_Click(object sender, EventArgs e)
        {
            animationMode = 1;
        }

        private void Continuous_Rotate_Button_Click(object sender, EventArgs e)
        {
            animationMode = 2;
        }

        // непрерывное масштабирование: увеличить
        private void Continuous_Scale_Up_Button_Click(object sender, EventArgs e)
        {
            animationMode = 3;
        }

        // непрерывное масштабирование: уменьшить
        private void Continuous_Scale_Down_Button_Click(object sender, EventArgs e)
        {
            animationMode = 4;
        }


    }
}
