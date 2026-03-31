namespace LR1T2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox = new PictureBox();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            buttonDrawLine = new Button();
            textBoxY2 = new TextBox();
            textBoxX2 = new TextBox();
            textBoxY1 = new TextBox();
            textBoxX1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
            numericUpDownDashStep = new NumericUpDown();
            label2 = new Label();
            comboBoxLineType = new ComboBox();
            label1 = new Label();
            ThickLine_СheckBox = new CheckBox();
            ColorSelection_Button = new Button();
            Make_Button = new Button();
            Clear_Button = new Button();
            groupBox1 = new GroupBox();
            radioButtonBresenham = new RadioButton();
            Contour_RadioButton = new RadioButton();
            Filling_RadioButton = new RadioButton();
            CDA_RadioButton = new RadioButton();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDashStep).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // PictureBox
            // 
            PictureBox.BackColor = SystemColors.AppWorkspace;
            PictureBox.Location = new Point(9, 12);
            PictureBox.Margin = new Padding(0);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(431, 426);
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            PictureBox.MouseClick += PictureBox_MouseClick;
            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.MouseUp += PictureBox_MouseUp;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(ThickLine_СheckBox);
            panel1.Controls.Add(ColorSelection_Button);
            panel1.Controls.Add(Make_Button);
            panel1.Controls.Add(Clear_Button);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(443, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 426);
            panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonDrawLine);
            groupBox3.Controls.Add(textBoxY2);
            groupBox3.Controls.Add(textBoxX2);
            groupBox3.Controls.Add(textBoxY1);
            groupBox3.Controls.Add(textBoxX1);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(13, 209);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(214, 125);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Рисование отрезка";
            // 
            // buttonDrawLine
            // 
            buttonDrawLine.Location = new Point(135, 96);
            buttonDrawLine.Name = "buttonDrawLine";
            buttonDrawLine.Size = new Size(83, 23);
            buttonDrawLine.TabIndex = 8;
            buttonDrawLine.Text = "Нарисовать";
            buttonDrawLine.UseVisualStyleBackColor = true;
            // 
            // textBoxY2
            // 
            textBoxY2.Location = new Point(29, 96);
            textBoxY2.Name = "textBoxY2";
            textBoxY2.Size = new Size(100, 23);
            textBoxY2.TabIndex = 7;
            // 
            // textBoxX2
            // 
            textBoxX2.Location = new Point(30, 71);
            textBoxX2.Name = "textBoxX2";
            textBoxX2.Size = new Size(100, 23);
            textBoxX2.TabIndex = 6;
            // 
            // textBoxY1
            // 
            textBoxY1.Location = new Point(31, 42);
            textBoxY1.Name = "textBoxY1";
            textBoxY1.Size = new Size(100, 23);
            textBoxY1.TabIndex = 5;
            // 
            // textBoxX1
            // 
            textBoxX1.Location = new Point(32, 14);
            textBoxX1.Name = "textBoxX1";
            textBoxX1.Size = new Size(103, 23);
            textBoxX1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 93);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 3;
            label7.Text = "Y2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 66);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 2;
            label6.Text = "X2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 40);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 1;
            label5.Text = "Y1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 17);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 0;
            label4.Text = "X1";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(numericUpDownDashStep);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(comboBoxLineType);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(9, 132);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(218, 71);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Настройка линии";
            // 
            // numericUpDownDashStep
            // 
            numericUpDownDashStep.Location = new Point(93, 42);
            numericUpDownDashStep.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDownDashStep.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownDashStep.Name = "numericUpDownDashStep";
            numericUpDownDashStep.Size = new Size(101, 23);
            numericUpDownDashStep.TabIndex = 3;
            numericUpDownDashStep.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 42);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Шаг пунктира";
            // 
            // comboBoxLineType
            // 
            comboBoxLineType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLineType.FormattingEnabled = true;
            comboBoxLineType.Location = new Point(79, 16);
            comboBoxLineType.Name = "comboBoxLineType";
            comboBoxLineType.Size = new Size(121, 23);
            comboBoxLineType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 19);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Тип линии";
            // 
            // ThickLine_СheckBox
            // 
            ThickLine_СheckBox.AutoSize = true;
            ThickLine_СheckBox.Location = new Point(107, 369);
            ThickLine_СheckBox.Name = "ThickLine_СheckBox";
            ThickLine_СheckBox.Size = new Size(106, 19);
            ThickLine_СheckBox.TabIndex = 4;
            ThickLine_СheckBox.Text = "Толстая линия";
            ThickLine_СheckBox.UseVisualStyleBackColor = true;
            // 
            // ColorSelection_Button
            // 
            ColorSelection_Button.FlatStyle = FlatStyle.Popup;
            ColorSelection_Button.Location = new Point(3, 369);
            ColorSelection_Button.Name = "ColorSelection_Button";
            ColorSelection_Button.Size = new Size(104, 23);
            ColorSelection_Button.TabIndex = 3;
            ColorSelection_Button.Text = "Выбор цвета";
            ColorSelection_Button.UseVisualStyleBackColor = true;
            ColorSelection_Button.Click += ColorSelection_Button_Click;
            // 
            // Make_Button
            // 
            Make_Button.FlatStyle = FlatStyle.Popup;
            Make_Button.Location = new Point(3, 398);
            Make_Button.Name = "Make_Button";
            Make_Button.Size = new Size(104, 23);
            Make_Button.TabIndex = 2;
            Make_Button.Text = "Выполнить";
            Make_Button.UseVisualStyleBackColor = true;
            Make_Button.Click += Make_Button_Click;
            // 
            // Clear_Button
            // 
            Clear_Button.FlatStyle = FlatStyle.Popup;
            Clear_Button.Location = new Point(113, 398);
            Clear_Button.Name = "Clear_Button";
            Clear_Button.Size = new Size(114, 23);
            Clear_Button.TabIndex = 1;
            Clear_Button.Text = "Очистить";
            Clear_Button.UseVisualStyleBackColor = true;
            Clear_Button.Click += Clear_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonBresenham);
            groupBox1.Controls.Add(Contour_RadioButton);
            groupBox1.Controls.Add(Filling_RadioButton);
            groupBox1.Controls.Add(CDA_RadioButton);
            groupBox1.Location = new Point(3, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 114);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите алгоритм";
            // 
            // radioButtonBresenham
            // 
            radioButtonBresenham.AutoSize = true;
            radioButtonBresenham.Location = new Point(6, 95);
            radioButtonBresenham.Name = "radioButtonBresenham";
            radioButtonBresenham.Size = new Size(148, 19);
            radioButtonBresenham.TabIndex = 3;
            radioButtonBresenham.TabStop = true;
            radioButtonBresenham.Text = "Алгоритм Брезенхема";
            radioButtonBresenham.UseVisualStyleBackColor = true;
            radioButtonBresenham.CheckedChanged += radioButtonBresenham_CheckedChanged;
            // 
            // Contour_RadioButton
            // 
            Contour_RadioButton.AutoSize = true;
            Contour_RadioButton.Location = new Point(6, 72);
            Contour_RadioButton.Name = "Contour_RadioButton";
            Contour_RadioButton.Size = new Size(165, 19);
            Contour_RadioButton.TabIndex = 2;
            Contour_RadioButton.TabStop = true;
            Contour_RadioButton.Text = "Обход сложного контура";
            Contour_RadioButton.UseVisualStyleBackColor = true;
            // 
            // Filling_RadioButton
            // 
            Filling_RadioButton.AutoSize = true;
            Filling_RadioButton.Location = new Point(6, 47);
            Filling_RadioButton.Name = "Filling_RadioButton";
            Filling_RadioButton.Size = new Size(70, 19);
            Filling_RadioButton.TabIndex = 1;
            Filling_RadioButton.TabStop = true;
            Filling_RadioButton.Text = "Заливка";
            Filling_RadioButton.UseVisualStyleBackColor = true;
            // 
            // CDA_RadioButton
            // 
            CDA_RadioButton.AutoSize = true;
            CDA_RadioButton.Location = new Point(6, 22);
            CDA_RadioButton.Name = "CDA_RadioButton";
            CDA_RadioButton.Size = new Size(108, 19);
            CDA_RadioButton.TabIndex = 0;
            CDA_RadioButton.TabStop = true;
            CDA_RadioButton.Text = "Обычный ЦДА";
            CDA_RadioButton.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 450);
            Controls.Add(panel1);
            Controls.Add(PictureBox);
            Name = "Form3";
            Text = "Растровые алгоритмы";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDashStep).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PictureBox;
        private Panel panel1;
        private GroupBox groupBox1;
        private RadioButton CDA_RadioButton;
        private Button Clear_Button;
        private Button Make_Button;
        private RadioButton Filling_RadioButton;
        private Button ColorSelection_Button;
        private ColorDialog colorDialog1;
        private CheckBox ThickLine_СheckBox;
        private RadioButton Contour_RadioButton;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDownDashStep;
        private Label label2;
        private ComboBox comboBoxLineType;
        private Label label1;
        private GroupBox groupBox3;
        private Button buttonDrawLine;
        private TextBox textBoxY2;
        private TextBox textBoxX2;
        private TextBox textBoxY1;
        private TextBox textBoxX1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private RadioButton radioButtonBresenham;
    }
}