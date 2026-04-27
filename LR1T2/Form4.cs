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
        int[,] kv = new int[4, 3]; // матрица тела
        int[,] osi = new int[4, 3]; // матрица координат осей
        int[,] matr_sdv = new int[3, 3]; // матрица преобразования

        int k, l; // элементы матрицы сдвига
        bool f = true; // переменная для запуска и остановки движения
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
        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
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

        // вывод квадрата на экран
        private void Draw_Kv()
        {
            Init_kvadrat(); // инициализация матрицы тела
            Init_matr_preob(k, l); // инициализация матрицы преобразования

            int[,] kv1 = Multiply_matr(kv, matr_sdv); // перемножение матриц

            Pen myPen = new Pen(Color.Blue, 2); // цвет линии и ширина

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем 1 сторону квадрата
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);

            // рисуем 2 сторону квадрата
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);

            // рисуем 3 сторону квадрата
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);

            // рисуем 4 сторону квадрата
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);

            g.Dispose();
            myPen.Dispose();
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

        // кнопка "Нарисовать фигуру"
        private void Draw_figure_Button_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Draw_Kv();
        }

        // кнопка "Очистить"
        private void Сlear_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(pictureBox1.BackColor);
            g.Dispose();
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
            k++;
            Draw_Kv();
            Thread.Sleep(100);
        }
    }
}
