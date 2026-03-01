using System.Text;

namespace LR1T2
{
    public partial class Form1 : Form
    {
        const int MaxN = 10; // максимально допустимая размерность матрицы
        const int MaxM = 10; // максимально допустимая размерность матрицы
        int n = 3; // текущая размерность матрицы
        int m = 3; // текущая размерность матрицы
        int rows1 = 3, cols1 = 3;      // размеры первой матрицы
        int rows2 = 3, cols2 = 3;      // размеры второй матрицы (или вектора)
        int lengthVector = 3;
        TextBox[,] MatrText = null; // матрица элементов типа TextBox
        double[,] Matr1 = new double[MaxN, MaxM]; // матрица 1 чисел с плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxM]; // матрица 2 чисел с плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxM]; // матрица результатов
        bool f1; // флажок, который указывает о вводе данных в матрицу Matr1
        bool f2; // флажок, который указывает о вводе данных в матрицу Matr2
        int dx = 40, dy = 50; // ширина и высота ячейки в MatrText[,]
        Form2 form2 = null; // экземпляр (объект) класса формы Form2

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f1 = f2 = false;
            int i, j;
            form2 = new Form2();
            MatrText = new TextBox[MaxN, MaxM];
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxM; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + j * dx, 10 + i * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    form2.Controls.Add(MatrText[i, j]);
                }
        }

        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < MaxN; i++)
                for (int j = 0; j < MaxM; j++)
                {
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Visible = false;
                }
        }

        private void AddMatrix1_Button_Click(object sender, EventArgs e)
        {
            if (N_TextBox.Text == "")
            {
                MessageBox.Show("Введите значение n", "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }
            if (M_TextBox.Text == "")
            {
                MessageBox.Show("Введите значение m", "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }

            // Сохраняем размеры первой матрицы
            if (MatrixVector1_СheckBox.Checked == true)
            {
                try
                {
                    rows1 = int.Parse(Vector_TextBox.Text);
                    cols1 = 1;
                }
                catch
                {
                    MessageBox.Show(
                    $"Значение для vector отсутствует или введено неверно.\n " +
                    $"Должно быть целое число не больше 10 и равняться количеству столбцов первой матрицы ({n})",
                    "Ошибка размерности",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            else
            {
                rows1 = int.Parse(N_TextBox.Text);
                cols1 = int.Parse(M_TextBox.Text);
            }

            // Временно используем n, m для отображения
            n = rows1;
            m = cols1;

            // Очищаем все TextBox'ы
            Clear_MatrText();

            // Показываем только нужные TextBox'ы
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    MatrText[i, j].Visible = true;
                    MatrText[i, j].TabIndex = i * m + j + 1;
                }

            // Настраиваем размер form2
            form2.Width = 10 + m * dx + 20;
            form2.Height = 10 + n * dy + form2.OK_Button.Height + 50;

            form2.OK_Button.Left = 10;
            form2.OK_Button.Top = 10 + n * dy + 10;
            form2.OK_Button.Width = form2.Width - 30;

            if (form2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                f1 = true;
                label2.Text = "true";
            }
        }

        private void AddMatrix2_Button_Click(object sender, EventArgs e)
        {
            if (N_TextBox.Text == "")
            {
                MessageBox.Show("Введите значение n", "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }
            if (M_TextBox.Text == "")
            {
                MessageBox.Show("Введите значение m", "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }

            // Сохраняем размеры второй матрицы
            if (MatrixVector2_СheckBox.Checked == true)
            {
                try
                {
                    rows2 = int.Parse(Vector_TextBox.Text);  // число строк (например, 3)
                    cols2 = 1;
                }
                catch
                {
                    MessageBox.Show(
                    $"Значение для vector отсутствует или введено неверно.\n " +
                    $"Должно быть целое число не больше 10 и равняться количеству столбцов первой матрицы ({n})",
                    "Ошибка размерности",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            else
            {
                rows2 = int.Parse(N_TextBox.Text);
                cols2 = int.Parse(M_TextBox.Text);
            }

            // Временно используем n, m для отображения
            n = rows2;
            m = cols2;

            // Очищаем все TextBox'ы
            Clear_MatrText();

            // Показываем только нужные TextBox'ы
            for (int i = 0; i < n; i++)           // i - это СТРОКИ (вертикаль)
                for (int j = 0; j < m; j++)       // j - это СТОЛБЦЫ (горизонталь)
                {
                    MatrText[i, j].Visible = true;
                    MatrText[i, j].TabIndex = i * m + j + 1;
                }

            // Настраиваем размер form2
            form2.Width = 10 + m * dx + 20;
            form2.Height = 10 + n * dy + form2.OK_Button.Height + 50;

            form2.OK_Button.Left = 10;
            form2.OK_Button.Top = 10 + n * dy + 10;
            form2.OK_Button.Width = form2.Width - 30;

            // Показываем форму
            if (form2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                f2 = true;
                label3.Text = "true";
            }
        }

        private void N_TextBox_Leave(object sender, EventArgs e)
        {
            if (N_TextBox.Text == "") return;

            int nn;
            nn = Int16.Parse(N_TextBox.Text);
            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void M_TextBox_Leave(object sender, EventArgs e)
        {
            if (M_TextBox.Text == "") return;

            int mm;
            mm = Int16.Parse(M_TextBox.Text);
            if (mm != m)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void Vector_TextBox_Leave(object sender, EventArgs e)
        {
            if (Vector_TextBox.Text == "") return;

            int vector;
            vector = Int16.Parse(Vector_TextBox.Text);
            if (vector != lengthVector)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void Multiplication_Button_Click(object sender, EventArgs e)
        {
            if (!(f1 && f2)) return;

            // Проверка размерностей
            if (cols1 != rows2)
            {
                MessageBox.Show(
                    $"Нельзя умножить: cols1 ({cols1}) != rows2 ({rows2})",
                    "Ошибка размерности",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int resRows = rows1;
            int resCols = cols2;

            // Считаем результат
            for (int i = 0; i < resRows; i++)
                for (int j = 0; j < resCols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < cols1; k++)
                        sum += Matr1[i, k] * Matr2[k, j];
                    Matr3[i, j] = sum;
                }

            ShowResult(resRows, resCols, Matr3);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив
                                   // 1. Открыть файл для записи
            fw = new FileStream("Res_Matr.txt", FileMode.Create);
            // 2. Запись матрицы результата в файл

            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = n.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < n; j++)
                    msg += Matr3[i, j].ToString() + " ";
                msg += "\r\n";
                // добавить перевод строки
            }
            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. запись строк матрицы в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. Закрыть файл
            if (fw != null) fw.Close();
        }

        private void Sum_Button_Click(object sender, EventArgs e)
        {
            if (!(f1 && f2)) return;

            if (rows1 != rows2 || cols1 != cols2)
            {
                MessageBox.Show("Сложение возможно только для матриц одинакового размера!",
                                "Ошибка размерности", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < rows1; i++)
                for (int j = 0; j < cols1; j++)
                    Matr3[i, j] = Matr1[i, j] + Matr2[i, j];

            // вывод
            ShowResult(rows1, cols1, Matr3);
        }

        private void Sub_Button_Click(object sender, EventArgs e)
        {
            if (!(f1 && f2)) return;

            // 1) Проверка размерностей
            if (rows1 != rows2 || cols1 != cols2)
            {
                MessageBox.Show("Вычитание возможно только для матриц одинакового размера!",
                                "Ошибка размерности",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int resRows = rows1;
            int resCols = cols1;

            // 2) Вычисление: Matr3 = Matr1 - Matr2
            for (int i = 0; i < resRows; i++)
                for (int j = 0; j < resCols; j++)
                    Matr3[i, j] = Matr1[i, j] - Matr2[i, j];

            ShowResult(resRows, resCols, Matr3);
        }

        private void MatrixVectorMultiplication_Button_Click(object sender, EventArgs e)
        {
            // 1. Проверка ввода
            if (!(f1 && f2))
            {
                MessageBox.Show("Сначала введите матрицу и вектор!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Определяем, где матрица, а где вектор
            double[,] matrix;
            double[,] vector;
            int matRows, matCols, vecRows;

            if (cols1 > 1 && cols2 == 1)   // Matr1 — матрица, Matr2 — вектор
            {
                matrix = Matr1;
                matRows = rows1;
                matCols = cols1;
                vector = Matr2;
                vecRows = rows2;
            }
            else if (cols2 > 1 && cols1 == 1)   // Matr2 — матрица, Matr1 — вектор
            {
                matrix = Matr2;
                matRows = rows2;
                matCols = cols2;
                vector = Matr1;
                vecRows = rows1;
            }
            else
            {
                MessageBox.Show("Одна из матриц должна быть вектором (один столбец)!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Проверка размерностей
            if (matCols != vecRows)
            {
                MessageBox.Show($"Число столбцов матрицы ({matCols}) должно равняться числу строк вектора ({vecRows})!",
                                "Ошибка размерности", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Умножение матрицы на вектор
            double[] result = new double[matRows];

            for (int i = 0; i < matRows; i++)   // строки матрицы
            {
                double sum = 0;
                for (int j = 0; j < matCols; j++)   // столбцы матрицы / элементы вектора
                {
                    sum += matrix[i, j] * vector[j, 0];
                }
                result[i] = sum;
            }

            // 5. Вывод результата
            // Копируем result[] в Matr3
            for (int i = 0; i < matRows; i++)
                Matr3[i, 0] = result[i];

            ShowResult(matRows, 1, Matr3);
        }

        private void MatrixVector2_СheckBox_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "false";
            f2 = false;
        }

        private void MatrixVector1_СheckBox_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "false";
            f1 = false;
        }

        private void ShowResult(int rows, int cols, double[,] data)
        {
            Clear_MatrText();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    MatrText[i, j].Text = data[i, j].ToString("F3");
                    MatrText[i, j].Visible = true;
                    MatrText[i, j].TabIndex = i * cols + j + 1;
                }

            form2.Width = 10 + cols * dx + 20;
            form2.Height = 10 + rows * dy + form2.OK_Button.Height + 50;
            form2.OK_Button.Left = 10;
            form2.OK_Button.Top = 10 + rows * dy + 10;
            form2.OK_Button.Width = form2.Width - 30;

            form2.ShowDialog();
        }

        private void ShowScalar(double value)
        {
            Clear_MatrText();
            MatrText[0, 0].Text = value.ToString("F3");
            MatrText[0, 0].Visible = true;

            form2.Width = 10 + 1 * dx + 20;
            form2.Height = 10 + 1 * dy + form2.OK_Button.Height + 50;
            form2.OK_Button.Left = 10;
            form2.OK_Button.Top = 10 + 1 * dy + 10;
            form2.OK_Button.Width = form2.Width - 30;

            form2.ShowDialog();
        }
    }
}