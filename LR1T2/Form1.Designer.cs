namespace LR1T2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            N_TextBox = new TextBox();
            AddMatrix1_Button = new Button();
            AddMatrix2_Button = new Button();
            Multiplication_Button = new Button();
            Save_Button = new Button();
            label2 = new Label();
            label3 = new Label();
            Sum_Button = new Button();
            Sub_Button = new Button();
            M_TextBox = new TextBox();
            label4 = new Label();
            Const_TextBox = new TextBox();
            label5 = new Label();
            MatrixVector1_СheckBox = new CheckBox();
            MatrixVector2_СheckBox = new CheckBox();
            label6 = new Label();
            Vector_TextBox = new TextBox();
            MatrixVectorMultiplication_Button = new Button();
            Vector_artwork = new Button();
            Transpose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 0;
            label1.Text = "n = ";
            // 
            // N_TextBox
            // 
            N_TextBox.BorderStyle = BorderStyle.FixedSingle;
            N_TextBox.Location = new Point(46, 4);
            N_TextBox.Margin = new Padding(3, 2, 3, 2);
            N_TextBox.Name = "N_TextBox";
            N_TextBox.Size = new Size(230, 23);
            N_TextBox.TabIndex = 1;
            N_TextBox.Leave += N_TextBox_Leave;
            // 
            // AddMatrix1_Button
            // 
            AddMatrix1_Button.Location = new Point(10, 112);
            AddMatrix1_Button.Margin = new Padding(3, 2, 3, 2);
            AddMatrix1_Button.Name = "AddMatrix1_Button";
            AddMatrix1_Button.Size = new Size(116, 22);
            AddMatrix1_Button.TabIndex = 2;
            AddMatrix1_Button.Text = "Ввод матрицы 1";
            AddMatrix1_Button.UseVisualStyleBackColor = true;
            AddMatrix1_Button.Click += AddMatrix1_Button_Click;
            // 
            // AddMatrix2_Button
            // 
            AddMatrix2_Button.Location = new Point(10, 139);
            AddMatrix2_Button.Margin = new Padding(3, 2, 3, 2);
            AddMatrix2_Button.Name = "AddMatrix2_Button";
            AddMatrix2_Button.Size = new Size(116, 22);
            AddMatrix2_Button.TabIndex = 3;
            AddMatrix2_Button.Text = "Ввод матрицы 2";
            AddMatrix2_Button.UseVisualStyleBackColor = true;
            AddMatrix2_Button.Click += AddMatrix2_Button_Click;
            // 
            // Multiplication_Button
            // 
            Multiplication_Button.Location = new Point(10, 165);
            Multiplication_Button.Margin = new Padding(3, 2, 3, 2);
            Multiplication_Button.Name = "Multiplication_Button";
            Multiplication_Button.Size = new Size(266, 22);
            Multiplication_Button.TabIndex = 4;
            Multiplication_Button.Text = "Произведение";
            Multiplication_Button.UseVisualStyleBackColor = true;
            Multiplication_Button.Click += Multiplication_Button_Click;
            // 
            // Save_Button
            // 
            Save_Button.Location = new Point(10, 217);
            Save_Button.Margin = new Padding(3, 2, 3, 2);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(266, 22);
            Save_Button.TabIndex = 5;
            Save_Button.Text = "Сохранить в файле “Res_Matr.txt";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += Save_Button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 115);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "false";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 141);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = "false";
            // 
            // Sum_Button
            // 
            Sum_Button.Location = new Point(10, 191);
            Sum_Button.Margin = new Padding(3, 2, 3, 2);
            Sum_Button.Name = "Sum_Button";
            Sum_Button.Size = new Size(125, 22);
            Sum_Button.TabIndex = 8;
            Sum_Button.Text = "Сумма";
            Sum_Button.UseVisualStyleBackColor = true;
            Sum_Button.Click += Sum_Button_Click;
            // 
            // Sub_Button
            // 
            Sub_Button.Location = new Point(151, 191);
            Sub_Button.Margin = new Padding(3, 2, 3, 2);
            Sub_Button.Name = "Sub_Button";
            Sub_Button.Size = new Size(125, 22);
            Sub_Button.TabIndex = 9;
            Sub_Button.Text = "Вычетание";
            Sub_Button.UseVisualStyleBackColor = true;
            Sub_Button.Click += Sub_Button_Click;
            // 
            // M_TextBox
            // 
            M_TextBox.BorderStyle = BorderStyle.FixedSingle;
            M_TextBox.Location = new Point(46, 31);
            M_TextBox.Margin = new Padding(3, 2, 3, 2);
            M_TextBox.Name = "M_TextBox";
            M_TextBox.Size = new Size(230, 23);
            M_TextBox.TabIndex = 10;
            M_TextBox.Leave += M_TextBox_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 33);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 11;
            label4.Text = "m = ";
            // 
            // Const_TextBox
            // 
            Const_TextBox.BorderStyle = BorderStyle.FixedSingle;
            Const_TextBox.Location = new Point(66, 85);
            Const_TextBox.Margin = new Padding(3, 2, 3, 2);
            Const_TextBox.Name = "Const_TextBox";
            Const_TextBox.Size = new Size(210, 23);
            Const_TextBox.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 87);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 13;
            label5.Text = "const = ";
            // 
            // MatrixVector1_СheckBox
            // 
            MatrixVector1_СheckBox.AutoSize = true;
            MatrixVector1_СheckBox.Location = new Point(169, 115);
            MatrixVector1_СheckBox.Name = "MatrixVector1_СheckBox";
            MatrixVector1_СheckBox.Size = new Size(117, 19);
            MatrixVector1_СheckBox.TabIndex = 14;
            MatrixVector1_СheckBox.Text = "Матрица-вектор";
            MatrixVector1_СheckBox.UseVisualStyleBackColor = true;
            MatrixVector1_СheckBox.CheckedChanged += MatrixVector1_СheckBox_CheckedChanged;
            // 
            // MatrixVector2_СheckBox
            // 
            MatrixVector2_СheckBox.AutoSize = true;
            MatrixVector2_СheckBox.Location = new Point(169, 142);
            MatrixVector2_СheckBox.Name = "MatrixVector2_СheckBox";
            MatrixVector2_СheckBox.Size = new Size(117, 19);
            MatrixVector2_СheckBox.TabIndex = 15;
            MatrixVector2_СheckBox.Text = "Матрица-вектор";
            MatrixVector2_СheckBox.UseVisualStyleBackColor = true;
            MatrixVector2_СheckBox.CheckedChanged += MatrixVector2_СheckBox_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 60);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 17;
            label6.Text = "vector = ";
            // 
            // Vector_TextBox
            // 
            Vector_TextBox.BorderStyle = BorderStyle.FixedSingle;
            Vector_TextBox.Location = new Point(70, 58);
            Vector_TextBox.Margin = new Padding(3, 2, 3, 2);
            Vector_TextBox.Name = "Vector_TextBox";
            Vector_TextBox.Size = new Size(206, 23);
            Vector_TextBox.TabIndex = 16;
            Vector_TextBox.Leave += Vector_TextBox_Leave;
            // 
            // MatrixVectorMultiplication_Button
            // 
            MatrixVectorMultiplication_Button.Location = new Point(10, 244);
            MatrixVectorMultiplication_Button.Name = "MatrixVectorMultiplication_Button";
            MatrixVectorMultiplication_Button.Size = new Size(266, 23);
            MatrixVectorMultiplication_Button.TabIndex = 18;
            MatrixVectorMultiplication_Button.Text = "Умножение матрицы на вектор";
            MatrixVectorMultiplication_Button.UseVisualStyleBackColor = true;
            MatrixVectorMultiplication_Button.Click += MatrixVectorMultiplication_Button_Click;
            // 
            // Vector_artwork
            // 
            Vector_artwork.Location = new Point(12, 273);
            Vector_artwork.Name = "Vector_artwork";
            Vector_artwork.Size = new Size(264, 23);
            Vector_artwork.TabIndex = 19;
            Vector_artwork.Text = "Векторное произведение (a × b)";
            Vector_artwork.UseVisualStyleBackColor = true;
            Vector_artwork.Click += Vector_artwork_Click;
            // 
            // Transpose
            // 
            Transpose.Location = new Point(10, 302);
            Transpose.Name = "Transpose";
            Transpose.Size = new Size(266, 23);
            Transpose.TabIndex = 20;
            Transpose.Text = "Транспонирование (Aᵀ)";
            Transpose.UseVisualStyleBackColor = true;
            Transpose.Click += Transpose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 337);
            Controls.Add(Transpose);
            Controls.Add(Vector_artwork);
            Controls.Add(MatrixVectorMultiplication_Button);
            Controls.Add(label6);
            Controls.Add(Vector_TextBox);
            Controls.Add(MatrixVector2_СheckBox);
            Controls.Add(MatrixVector1_СheckBox);
            Controls.Add(label5);
            Controls.Add(Const_TextBox);
            Controls.Add(label4);
            Controls.Add(M_TextBox);
            Controls.Add(Sub_Button);
            Controls.Add(Sum_Button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Save_Button);
            Controls.Add(Multiplication_Button);
            Controls.Add(AddMatrix2_Button);
            Controls.Add(AddMatrix1_Button);
            Controls.Add(N_TextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox N_TextBox;
        private Button AddMatrix1_Button;
        private Button AddMatrix2_Button;
        private Button Multiplication_Button;
        private Button Save_Button;
        private Label label2;
        private Label label3;
        private Button Sum_Button;
        private Button Sub_Button;
        private TextBox M_TextBox;
        private Label label4;
        private TextBox Const_TextBox;
        private Label label5;
        private CheckBox MatrixVector1_СheckBox;
        private CheckBox MatrixVector2_СheckBox;
        private Label label6;
        private TextBox Vector_TextBox;
        private Button MatrixVectorMultiplication_Button;
        private Button Vector_artwork;
        private Button Transpose;
    }
}
