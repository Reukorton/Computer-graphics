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
            Vector_Artwork_Button = new Button();
            Transpose_Button = new Button();
            Vectore_Module_Button = new Button();
            Scalar_Product_Button = new Button();
            MultiplicationMatrixByConst_Button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "n = ";
            // 
            // N_TextBox
            // 
            N_TextBox.BorderStyle = BorderStyle.FixedSingle;
            N_TextBox.Location = new Point(53, 5);
            N_TextBox.Name = "N_TextBox";
            N_TextBox.Size = new Size(263, 27);
            N_TextBox.TabIndex = 1;
            N_TextBox.Leave += N_TextBox_Leave;
            // 
            // AddMatrix1_Button
            // 
            AddMatrix1_Button.Location = new Point(11, 149);
            AddMatrix1_Button.Name = "AddMatrix1_Button";
            AddMatrix1_Button.Size = new Size(133, 29);
            AddMatrix1_Button.TabIndex = 2;
            AddMatrix1_Button.Text = "Ввод матрицы 1";
            AddMatrix1_Button.UseVisualStyleBackColor = true;
            AddMatrix1_Button.Click += AddMatrix1_Button_Click;
            // 
            // AddMatrix2_Button
            // 
            AddMatrix2_Button.Location = new Point(11, 185);
            AddMatrix2_Button.Name = "AddMatrix2_Button";
            AddMatrix2_Button.Size = new Size(133, 29);
            AddMatrix2_Button.TabIndex = 3;
            AddMatrix2_Button.Text = "Ввод матрицы 2";
            AddMatrix2_Button.UseVisualStyleBackColor = true;
            AddMatrix2_Button.Click += AddMatrix2_Button_Click;
            // 
            // Multiplication_Button
            // 
            Multiplication_Button.Location = new Point(11, 220);
            Multiplication_Button.Name = "Multiplication_Button";
            Multiplication_Button.Size = new Size(304, 29);
            Multiplication_Button.TabIndex = 4;
            Multiplication_Button.Text = "Произведение";
            Multiplication_Button.UseVisualStyleBackColor = true;
            Multiplication_Button.Click += Multiplication_Button_Click;
            // 
            // Save_Button
            // 
            Save_Button.Location = new Point(11, 289);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(304, 29);
            Save_Button.TabIndex = 5;
            Save_Button.Text = "Сохранить в файле “Res_Matr.txt";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += Save_Button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 153);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 6;
            label2.Text = "false";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 188);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 7;
            label3.Text = "false";
            // 
            // Sum_Button
            // 
            Sum_Button.Location = new Point(11, 255);
            Sum_Button.Name = "Sum_Button";
            Sum_Button.Size = new Size(143, 29);
            Sum_Button.TabIndex = 8;
            Sum_Button.Text = "Сумма";
            Sum_Button.UseVisualStyleBackColor = true;
            Sum_Button.Click += Sum_Button_Click;
            // 
            // Sub_Button
            // 
            Sub_Button.Location = new Point(173, 255);
            Sub_Button.Name = "Sub_Button";
            Sub_Button.Size = new Size(143, 29);
            Sub_Button.TabIndex = 9;
            Sub_Button.Text = "Вычетание";
            Sub_Button.UseVisualStyleBackColor = true;
            Sub_Button.Click += Sub_Button_Click;
            // 
            // M_TextBox
            // 
            M_TextBox.BorderStyle = BorderStyle.FixedSingle;
            M_TextBox.Location = new Point(53, 41);
            M_TextBox.Name = "M_TextBox";
            M_TextBox.Size = new Size(263, 27);
            M_TextBox.TabIndex = 10;
            M_TextBox.Leave += M_TextBox_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 44);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 11;
            label4.Text = "m = ";
            // 
            // Const_TextBox
            // 
            Const_TextBox.BorderStyle = BorderStyle.FixedSingle;
            Const_TextBox.Location = new Point(75, 113);
            Const_TextBox.Name = "Const_TextBox";
            Const_TextBox.Size = new Size(240, 27);
            Const_TextBox.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 116);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 13;
            label5.Text = "const = ";
            // 
            // MatrixVector1_СheckBox
            // 
            MatrixVector1_СheckBox.AutoSize = true;
            MatrixVector1_СheckBox.Location = new Point(193, 153);
            MatrixVector1_СheckBox.Margin = new Padding(3, 4, 3, 4);
            MatrixVector1_СheckBox.Name = "MatrixVector1_СheckBox";
            MatrixVector1_СheckBox.Size = new Size(146, 24);
            MatrixVector1_СheckBox.TabIndex = 14;
            MatrixVector1_СheckBox.Text = "Матрица-вектор";
            MatrixVector1_СheckBox.UseVisualStyleBackColor = true;
            MatrixVector1_СheckBox.CheckedChanged += MatrixVector1_СheckBox_CheckedChanged;
            // 
            // MatrixVector2_СheckBox
            // 
            MatrixVector2_СheckBox.AutoSize = true;
            MatrixVector2_СheckBox.Location = new Point(193, 189);
            MatrixVector2_СheckBox.Margin = new Padding(3, 4, 3, 4);
            MatrixVector2_СheckBox.Name = "MatrixVector2_СheckBox";
            MatrixVector2_СheckBox.Size = new Size(146, 24);
            MatrixVector2_СheckBox.TabIndex = 15;
            MatrixVector2_СheckBox.Text = "Матрица-вектор";
            MatrixVector2_СheckBox.UseVisualStyleBackColor = true;
            MatrixVector2_СheckBox.CheckedChanged += MatrixVector2_СheckBox_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 80);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 17;
            label6.Text = "vector = ";
            // 
            // Vector_TextBox
            // 
            Vector_TextBox.BorderStyle = BorderStyle.FixedSingle;
            Vector_TextBox.Location = new Point(80, 77);
            Vector_TextBox.Name = "Vector_TextBox";
            Vector_TextBox.Size = new Size(235, 27);
            Vector_TextBox.TabIndex = 16;
            Vector_TextBox.Leave += Vector_TextBox_Leave;
            // 
            // MatrixVectorMultiplication_Button
            // 
            MatrixVectorMultiplication_Button.Location = new Point(11, 325);
            MatrixVectorMultiplication_Button.Margin = new Padding(3, 4, 3, 4);
            MatrixVectorMultiplication_Button.Name = "MatrixVectorMultiplication_Button";
            MatrixVectorMultiplication_Button.Size = new Size(304, 31);
            MatrixVectorMultiplication_Button.TabIndex = 18;
            MatrixVectorMultiplication_Button.Text = "Умножение матрицы на вектор";
            MatrixVectorMultiplication_Button.UseVisualStyleBackColor = true;
            MatrixVectorMultiplication_Button.Click += MatrixVectorMultiplication_Button_Click;
            // 
            // Vector_Artwork_Button
            // 
            Vector_Artwork_Button.Location = new Point(11, 364);
            Vector_Artwork_Button.Margin = new Padding(3, 4, 3, 4);
            Vector_Artwork_Button.Name = "Vector_Artwork_Button";
            Vector_Artwork_Button.Size = new Size(304, 31);
            Vector_Artwork_Button.TabIndex = 19;
            Vector_Artwork_Button.Text = "Векторное произведение (a × b)";
            Vector_Artwork_Button.UseVisualStyleBackColor = true;
            Vector_Artwork_Button.Click += Vector_Artwork_Button_Click;
            // 
            // Transpose_Button
            // 
            Transpose_Button.Location = new Point(11, 403);
            Transpose_Button.Margin = new Padding(3, 4, 3, 4);
            Transpose_Button.Name = "Transpose_Button";
            Transpose_Button.Size = new Size(304, 31);
            Transpose_Button.TabIndex = 20;
            Transpose_Button.Text = "Транспонирование (Aᵀ)";
            Transpose_Button.UseVisualStyleBackColor = true;
            Transpose_Button.Click += Transpose_Button_Click;
            // 
            // Vectore_Module_Button
            // 
            Vectore_Module_Button.Location = new Point(11, 444);
            Vectore_Module_Button.Margin = new Padding(3, 4, 3, 4);
            Vectore_Module_Button.Name = "Vectore_Module_Button";
            Vectore_Module_Button.Size = new Size(304, 31);
            Vectore_Module_Button.TabIndex = 21;
            Vectore_Module_Button.Text = "Модуль вектора";
            Vectore_Module_Button.UseVisualStyleBackColor = true;
            Vectore_Module_Button.Click += Vectore_Module_Button_Click;
            // 
            // Scalar_Product_Button
            // 
            Scalar_Product_Button.Location = new Point(11, 483);
            Scalar_Product_Button.Margin = new Padding(3, 4, 3, 4);
            Scalar_Product_Button.Name = "Scalar_Product_Button";
            Scalar_Product_Button.Size = new Size(304, 31);
            Scalar_Product_Button.TabIndex = 22;
            Scalar_Product_Button.Text = "Скалярное произведение векторов";
            Scalar_Product_Button.UseVisualStyleBackColor = true;
            Scalar_Product_Button.Click += Scalar_Product_Button_Click;
            // 
            // MultiplicationMatrixByConst_Button
            // 
            MultiplicationMatrixByConst_Button.Location = new Point(14, 521);
            MultiplicationMatrixByConst_Button.Margin = new Padding(3, 4, 3, 4);
            MultiplicationMatrixByConst_Button.Name = "MultiplicationMatrixByConst_Button";
            MultiplicationMatrixByConst_Button.Size = new Size(302, 31);
            MultiplicationMatrixByConst_Button.TabIndex = 23;
            MultiplicationMatrixByConst_Button.Text = " Умножение матрицы на константу";
            MultiplicationMatrixByConst_Button.UseVisualStyleBackColor = true;
            MultiplicationMatrixByConst_Button.Click += MultiplicationMatrixByConst_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 568);
            Controls.Add(MultiplicationMatrixByConst_Button);
            Controls.Add(Scalar_Product_Button);
            Controls.Add(Vectore_Module_Button);
            Controls.Add(Transpose_Button);
            Controls.Add(Vector_Artwork_Button);
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
        private Button Vector_Artwork_Button;
        private Button Transpose_Button;
        private Button Vectore_Module_Button;
        private Button Scalar_Product_Button;
        private Button MultiplicationMatrixByConst_Button;
    }
}
