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
        Bitmap myBitmap; // объект Bitmap для вывода отрезка
        Color currentBorderColor; // текущий цвет отрезка и текущий цвет заливки
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Проверяем, выбрал ли пользователь алгоритм
            if (radioButton1.Checked == true)
            {
                xn = e.X;  // Начальная точка отрезка
                yn = e.Y;
            }
            else
            {
                MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            // Создаем объект Graphics для рисования на PictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // Конечные координаты
            xk = e.X;
            yk = e.Y;

            dx = xk - xn;  // Разница между конечной и начальной точкой
            dy = yk - yn;
            numberNodes = 200;  // Количество узлов для аппроксимации отрезка
            xOutput = xn;
            yOutput = yn;

            // Рисуем отрезок с использованием ЦДА
            for (index = 1; index <= numberNodes; index++)
            {
                // Рисуем прямоугольник для каждого пикселя
                g.DrawRectangle(new Pen(currentBorderColor, 1), (int)xOutput, (int)yOutput, 2, 2);

                // Переходим к следующей точке
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            xn = xStart;
            yn = yStart;
            xk = xEnd;
            yk = yEnd;
            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;
            for (index = 1; index <= numberNodes; index++)
            {
                myBitmap.SetPixel((int)xOutput, (int)yOutput, currentBorderColor);
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();  // Открыть диалог выбора цвета
            if (dialogResult == DialogResult.OK && radioButton1.Checked)
            {
                currentBorderColor = colorDialog1.Color;  // Устанавливаем выбранный цвет
            }
        }

        private void FloodFill(int x1, int y1)
        {
            // получаем цвет текущего пикселя с координатами x1, y1
            Color oldPixelColor = myBitmap.GetPixel(x1, y1);

            // сравнение цветов происходит в формате RGB
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb()) && (oldPixelColor.ToArgb() != Color.Green.ToArgb()))
            {
                // перекрашиваем пиксель
                myBitmap.SetPixel(x1, y1, Color.Green);

                // вызываем метод для 4-х соседних пикселей
                FloodFill(x1 + 1, y1);
                FloodFill(x1 - 1, y1);
                FloodFill(x1, y1 + 1);
                FloodFill(x1, y1 - 1);
            }
            else
            {
                // выходим из метода, если пиксель уже залит или это контур
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Отключаем кнопки
            button1.Enabled = false;
            button2.Enabled = false;

            // Создаем новый экземпляр Bitmap размером с элемент PictureBox
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    // Рисуем прямоугольник
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);
                    // Рисуем треугольник
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);
                }
                else
                {
                    if (radioButton2.Checked == true)
                    {
                        // Получаем растр созданного рисунка в myBitmap
                        myBitmap = pictureBox1.Image as Bitmap;

                        // Задаем координаты затравки
                        xn = 160;
                        yn = 40;

                        // Вызываем рекурсивную процедуру заливки с затравкой
                        FloodFill(xn, yn);
                    }
                }
                // Передаем полученный растр myBitmap в элемент pictureBox
                pictureBox1.Image = myBitmap;

                // Обновляем pictureBox и активируем кнопки
                pictureBox1.Refresh();
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
    }

}
