namespace LR1T2
{
    partial class Form6
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            comboBoxFigure = new ComboBox();
            btnReset = new Button();
            btnAutoRotate = new Button();
            btnAutoMove = new Button();
            btnDirection = new Button();
            btnSpeedMinus = new Button();
            btnSpeedPlus = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            comboBoxAction = new ComboBox();
            comboBoxAxis = new ComboBox();
            btnMinus = new Button();
            btnPlus = new Button();
            colorDialog1 = new ColorDialog();
            groupBoxLineSettings = new GroupBox();
            comboBoxLineStyle = new ComboBox();
            numericLineWidth = new NumericUpDown();
            label3 = new Label();
            btnLineColor = new Button();
            numericDashStep = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnRotateZ = new Button();
            btnRotateY = new Button();
            btnRotateX = new Button();
            btnApplyScale = new Button();
            btnApplyMove = new Button();
            txtScaleZ = new TextBox();
            txtScaleY = new TextBox();
            txtScaleX = new TextBox();
            txtMoveZ = new TextBox();
            txtMoveY = new TextBox();
            txtMoveX = new TextBox();
            btnRotateCustomAxis = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxLineSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDashStep).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(515, 506);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += PictureBox1_Paint;
            // 
            // comboBoxFigure
            // 
            comboBoxFigure.FormattingEnabled = true;
            comboBoxFigure.Location = new Point(536, 9);
            comboBoxFigure.Name = "comboBoxFigure";
            comboBoxFigure.Size = new Size(143, 23);
            comboBoxFigure.TabIndex = 3;
            comboBoxFigure.SelectedIndexChanged += ComboBoxFigure_SelectedIndexChanged;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(536, 488);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 23);
            btnReset.TabIndex = 4;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // btnAutoRotate
            // 
            btnAutoRotate.Location = new Point(536, 70);
            btnAutoRotate.Name = "btnAutoRotate";
            btnAutoRotate.Size = new Size(107, 23);
            btnAutoRotate.TabIndex = 8;
            btnAutoRotate.Text = "Авто вращение";
            btnAutoRotate.UseVisualStyleBackColor = true;
            btnAutoRotate.Click += BtnAutoRotate_Click;
            // 
            // btnAutoMove
            // 
            btnAutoMove.Location = new Point(536, 41);
            btnAutoMove.Name = "btnAutoMove";
            btnAutoMove.Size = new Size(107, 23);
            btnAutoMove.TabIndex = 9;
            btnAutoMove.Text = "Авто движение";
            btnAutoMove.UseVisualStyleBackColor = true;
            btnAutoMove.Click += BtnAutoMove_Click;
            // 
            // btnDirection
            // 
            btnDirection.Location = new Point(536, 99);
            btnDirection.Name = "btnDirection";
            btnDirection.Size = new Size(107, 23);
            btnDirection.TabIndex = 10;
            btnDirection.Text = "Направление";
            btnDirection.UseVisualStyleBackColor = true;
            btnDirection.Click += BtnDirection_Click;
            // 
            // btnSpeedMinus
            // 
            btnSpeedMinus.Location = new Point(685, 12);
            btnSpeedMinus.Name = "btnSpeedMinus";
            btnSpeedMinus.Size = new Size(84, 23);
            btnSpeedMinus.TabIndex = 11;
            btnSpeedMinus.Text = "Скорость -";
            btnSpeedMinus.UseVisualStyleBackColor = true;
            btnSpeedMinus.Click += BtnSpeedMinus_Click;
            // 
            // btnSpeedPlus
            // 
            btnSpeedPlus.Location = new Point(685, 41);
            btnSpeedPlus.Name = "btnSpeedPlus";
            btnSpeedPlus.Size = new Size(90, 23);
            btnSpeedPlus.TabIndex = 12;
            btnSpeedPlus.Text = "Скорость +";
            btnSpeedPlus.UseVisualStyleBackColor = true;
            btnSpeedPlus.Click += BtnSpeedPlus_Click;
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += Timer_Tick;
            // 
            // comboBoxAction
            // 
            comboBoxAction.FormattingEnabled = true;
            comboBoxAction.Location = new Point(536, 128);
            comboBoxAction.Name = "comboBoxAction";
            comboBoxAction.Size = new Size(107, 23);
            comboBoxAction.TabIndex = 13;
            // 
            // comboBoxAxis
            // 
            comboBoxAxis.FormattingEnabled = true;
            comboBoxAxis.Location = new Point(654, 128);
            comboBoxAxis.Name = "comboBoxAxis";
            comboBoxAxis.Size = new Size(115, 23);
            comboBoxAxis.TabIndex = 14;
            comboBoxAxis.SelectedIndexChanged += comboBoxAxis_SelectedIndexChanged;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(649, 70);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(126, 23);
            btnMinus.TabIndex = 16;
            btnMinus.Text = "выполнить в минус";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += BtnMinus_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(649, 99);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(126, 23);
            btnPlus.TabIndex = 17;
            btnPlus.Text = "выполнить в плюс";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += BtnPlus_Click;
            // 
            // groupBoxLineSettings
            // 
            groupBoxLineSettings.BackColor = Color.Transparent;
            groupBoxLineSettings.Controls.Add(comboBoxLineStyle);
            groupBoxLineSettings.Controls.Add(numericLineWidth);
            groupBoxLineSettings.Controls.Add(label3);
            groupBoxLineSettings.Controls.Add(btnLineColor);
            groupBoxLineSettings.Controls.Add(numericDashStep);
            groupBoxLineSettings.Controls.Add(label2);
            groupBoxLineSettings.Controls.Add(label1);
            groupBoxLineSettings.Location = new Point(536, 353);
            groupBoxLineSettings.Name = "groupBoxLineSettings";
            groupBoxLineSettings.Size = new Size(224, 129);
            groupBoxLineSettings.TabIndex = 22;
            groupBoxLineSettings.TabStop = false;
            groupBoxLineSettings.Text = "Настройка линии";
            // 
            // comboBoxLineStyle
            // 
            comboBoxLineStyle.FormattingEnabled = true;
            comboBoxLineStyle.Location = new Point(82, 16);
            comboBoxLineStyle.Name = "comboBoxLineStyle";
            comboBoxLineStyle.Size = new Size(121, 23);
            comboBoxLineStyle.TabIndex = 21;
            comboBoxLineStyle.SelectedIndexChanged += ComboBoxLineStyle_SelectedIndexChanged;
            // 
            // numericLineWidth
            // 
            numericLineWidth.Location = new Point(99, 74);
            numericLineWidth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericLineWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericLineWidth.Name = "numericLineWidth";
            numericLineWidth.Size = new Size(101, 23);
            numericLineWidth.TabIndex = 20;
            numericLineWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericLineWidth.ValueChanged += NumericLineWidth_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 76);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Толщина";
            // 
            // btnLineColor
            // 
            btnLineColor.Location = new Point(7, 101);
            btnLineColor.Name = "btnLineColor";
            btnLineColor.Size = new Size(94, 23);
            btnLineColor.TabIndex = 6;
            btnLineColor.Text = "Выбор цвета";
            btnLineColor.UseVisualStyleBackColor = true;
            btnLineColor.Click += BtnLineColor_Click;
            // 
            // numericDashStep
            // 
            numericDashStep.Location = new Point(99, 45);
            numericDashStep.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericDashStep.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDashStep.Name = "numericDashStep";
            numericDashStep.Size = new Size(101, 23);
            numericDashStep.TabIndex = 3;
            numericDashStep.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericDashStep.ValueChanged += NumericDashStep_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 47);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Шаг пунктира";
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
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRotateZ);
            groupBox1.Controls.Add(btnRotateY);
            groupBox1.Controls.Add(btnRotateX);
            groupBox1.Controls.Add(btnApplyScale);
            groupBox1.Controls.Add(btnApplyMove);
            groupBox1.Controls.Add(txtScaleZ);
            groupBox1.Controls.Add(txtScaleY);
            groupBox1.Controls.Add(txtScaleX);
            groupBox1.Controls.Add(txtMoveZ);
            groupBox1.Controls.Add(txtMoveY);
            groupBox1.Controls.Add(txtMoveX);
            groupBox1.Controls.Add(btnRotateCustomAxis);
            groupBox1.Location = new Point(536, 157);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(225, 190);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnRotateZ
            // 
            btnRotateZ.Location = new Point(150, 143);
            btnRotateZ.Name = "btnRotateZ";
            btnRotateZ.Size = new Size(75, 23);
            btnRotateZ.TabIndex = 14;
            btnRotateZ.Text = "Поворот Z";
            btnRotateZ.UseVisualStyleBackColor = true;
            btnRotateZ.Click += btnRotateZ_Click;
            // 
            // btnRotateY
            // 
            btnRotateY.Location = new Point(71, 167);
            btnRotateY.Name = "btnRotateY";
            btnRotateY.Size = new Size(81, 23);
            btnRotateY.TabIndex = 13;
            btnRotateY.Text = "Поворот Y";
            btnRotateY.UseVisualStyleBackColor = true;
            btnRotateY.Click += btnRotateY_Click;
            // 
            // btnRotateX
            // 
            btnRotateX.Location = new Point(0, 143);
            btnRotateX.Name = "btnRotateX";
            btnRotateX.Size = new Size(75, 23);
            btnRotateX.TabIndex = 12;
            btnRotateX.Text = "Поворот Х";
            btnRotateX.UseVisualStyleBackColor = true;
            btnRotateX.Click += btnRotateX_Click;
            // 
            // btnApplyScale
            // 
            btnApplyScale.Location = new Point(0, 85);
            btnApplyScale.Name = "btnApplyScale";
            btnApplyScale.Size = new Size(224, 23);
            btnApplyScale.TabIndex = 11;
            btnApplyScale.Text = "Масштабирование";
            btnApplyScale.UseVisualStyleBackColor = true;
            btnApplyScale.Click += btnApplyScale_Click;
            // 
            // btnApplyMove
            // 
            btnApplyMove.Location = new Point(0, 27);
            btnApplyMove.Name = "btnApplyMove";
            btnApplyMove.Size = new Size(233, 23);
            btnApplyMove.TabIndex = 10;
            btnApplyMove.Text = "Перемещение";
            btnApplyMove.UseVisualStyleBackColor = true;
            btnApplyMove.Click += btnApplyMove_Click;
            // 
            // txtScaleZ
            // 
            txtScaleZ.Location = new Point(172, 114);
            txtScaleZ.Name = "txtScaleZ";
            txtScaleZ.Size = new Size(47, 23);
            txtScaleZ.TabIndex = 6;
            // 
            // txtScaleY
            // 
            txtScaleY.Location = new Point(98, 114);
            txtScaleY.Name = "txtScaleY";
            txtScaleY.Size = new Size(44, 23);
            txtScaleY.TabIndex = 5;
            // 
            // txtScaleX
            // 
            txtScaleX.Location = new Point(7, 114);
            txtScaleX.Name = "txtScaleX";
            txtScaleX.Size = new Size(44, 23);
            txtScaleX.TabIndex = 4;
            // 
            // txtMoveZ
            // 
            txtMoveZ.Location = new Point(177, 56);
            txtMoveZ.Name = "txtMoveZ";
            txtMoveZ.Size = new Size(47, 23);
            txtMoveZ.TabIndex = 3;
            // 
            // txtMoveY
            // 
            txtMoveY.Location = new Point(99, 56);
            txtMoveY.Name = "txtMoveY";
            txtMoveY.Size = new Size(43, 23);
            txtMoveY.TabIndex = 2;
            // 
            // txtMoveX
            // 
            txtMoveX.Location = new Point(7, 56);
            txtMoveX.Name = "txtMoveX";
            txtMoveX.Size = new Size(44, 23);
            txtMoveX.TabIndex = 1;
            // 
            // btnRotateCustomAxis
            // 
            btnRotateCustomAxis.Location = new Point(0, 0);
            btnRotateCustomAxis.Name = "btnRotateCustomAxis";
            btnRotateCustomAxis.Size = new Size(224, 23);
            btnRotateCustomAxis.TabIndex = 0;
            btnRotateCustomAxis.Text = "Поворот вокруг оси 45°";
            btnRotateCustomAxis.UseVisualStyleBackColor = true;
            btnRotateCustomAxis.Click += btnRotateCustomAxis_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 523);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxLineSettings);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(comboBoxAxis);
            Controls.Add(comboBoxAction);
            Controls.Add(btnSpeedPlus);
            Controls.Add(btnSpeedMinus);
            Controls.Add(btnDirection);
            Controls.Add(btnAutoMove);
            Controls.Add(btnAutoRotate);
            Controls.Add(btnReset);
            Controls.Add(comboBoxFigure);
            Controls.Add(pictureBox1);
            Name = "Form6";
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxLineSettings.ResumeLayout(false);
            groupBoxLineSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDashStep).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBoxFigure;
        private Button btnReset;
        private Button btnAutoRotate;
        private Button btnAutoMove;
        private Button btnDirection;
        private Button btnSpeedMinus;
        private Button btnSpeedPlus;
        private System.Windows.Forms.Timer timer1;
        private ComboBox comboBoxAction;
        private ComboBox comboBoxAxis;
        private Button btnMinus;
        private Button btnPlus;
        private ColorDialog colorDialog1;
        private NumericUpDown numericLineWidth;
        private ComboBox comboBoxLineStyle;
        private NumericUpDown numericDashStep;
        private GroupBox groupBoxLineSettings;
        private NumericUpDown numericUpDownLineWidth;
        private Label label3;
        private Button btnLineColor;
        private NumericUpDown numericUpDownDashStep;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtMoveZ;
        private TextBox txtMoveY;
        private TextBox txtMoveX;
        private Button btnRotateCustomAxis;
        private Button btnApplyScale;
        private Button btnApplyMove;
        private TextBox txtScaleZ;
        private TextBox txtScaleY;
        private TextBox txtScaleX;
        private Button btnRotateX;
        private Button btnRotateZ;
        private Button btnRotateY;
    }
}