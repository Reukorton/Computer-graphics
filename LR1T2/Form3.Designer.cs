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
            ThickLine_СheckBox = new CheckBox();
            ColorSelection_Button = new Button();
            Make_Button = new Button();
            Clear_Button = new Button();
            groupBox1 = new GroupBox();
            Filling_RadioButton = new RadioButton();
            CDA_RadioButton = new RadioButton();
            colorDialog1 = new ColorDialog();
            Contour_RadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            panel1.SuspendLayout();
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
            // ThickLine_СheckBox
            // 
            ThickLine_СheckBox.AutoSize = true;
            ThickLine_СheckBox.Location = new Point(3, 344);
            ThickLine_СheckBox.Name = "ThickLine_СheckBox";
            ThickLine_СheckBox.Size = new Size(107, 19);
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
            groupBox1.Controls.Add(Contour_RadioButton);
            groupBox1.Controls.Add(Filling_RadioButton);
            groupBox1.Controls.Add(CDA_RadioButton);
            groupBox1.Location = new Point(3, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите алгоритм";
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
            // Contour_RadioButton
            // 
            Contour_RadioButton.AutoSize = true;
            Contour_RadioButton.Location = new Point(6, 72);
            Contour_RadioButton.Name = "Contour_RadioButton";
            Contour_RadioButton.Size = new Size(164, 19);
            Contour_RadioButton.TabIndex = 2;
            Contour_RadioButton.TabStop = true;
            Contour_RadioButton.Text = "Обход сложного контура";
            Contour_RadioButton.UseVisualStyleBackColor = true;
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
    }
}