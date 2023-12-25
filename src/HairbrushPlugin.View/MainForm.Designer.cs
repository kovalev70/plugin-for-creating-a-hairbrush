namespace HairbrushPlugin.View
{
    partial class MainForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            LeftPanel = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BuildButton = new Button();
            WidthOfTeethTextBox = new TextBox();
            ButtonsTableLayoutPanel = new TableLayoutPanel();
            RemoveContactButton = new PictureBox();
            EditContactButton = new PictureBox();
            AddContactButton = new PictureBox();
            DistanceBetweenTeethTextBox = new TextBox();
            LengthOfTeethTextBox = new TextBox();
            FullNameLabel = new Label();
            NumberOfTeethTextBox = new TextBox();
            EmailLabel = new Label();
            HandleLengthTextBox = new TextBox();
            PhoneNumberLabel = new Label();
            VKLable = new Label();
            DateOfBirthLabel = new Label();
            MainTableLayoutPanel = new TableLayoutPanel();
            RightPanel = new Panel();
            HairbrushPictureBox = new PictureBox();
            BirthdayPanel = new Panel();
            BirthdayPanelCloseButton = new PictureBox();
            BirthdaySurnamesLabel = new Label();
            BirthdayLabel = new Label();
            BirthdayPanelPictureBox = new PictureBox();
            LeftPanel.SuspendLayout();
            ButtonsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RemoveContactButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EditContactButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddContactButton).BeginInit();
            MainTableLayoutPanel.SuspendLayout();
            RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HairbrushPictureBox).BeginInit();
            BirthdayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BirthdayPanelCloseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BirthdayPanelPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = SystemColors.Window;
            LeftPanel.Controls.Add(label5);
            LeftPanel.Controls.Add(label4);
            LeftPanel.Controls.Add(label3);
            LeftPanel.Controls.Add(label2);
            LeftPanel.Controls.Add(label1);
            LeftPanel.Controls.Add(BuildButton);
            LeftPanel.Controls.Add(WidthOfTeethTextBox);
            LeftPanel.Controls.Add(ButtonsTableLayoutPanel);
            LeftPanel.Controls.Add(DistanceBetweenTeethTextBox);
            LeftPanel.Controls.Add(LengthOfTeethTextBox);
            LeftPanel.Controls.Add(FullNameLabel);
            LeftPanel.Controls.Add(NumberOfTeethTextBox);
            LeftPanel.Controls.Add(EmailLabel);
            LeftPanel.Controls.Add(HandleLengthTextBox);
            LeftPanel.Controls.Add(PhoneNumberLabel);
            LeftPanel.Controls.Add(VKLable);
            LeftPanel.Controls.Add(DateOfBirthLabel);
            LeftPanel.Dock = DockStyle.Fill;
            LeftPanel.Location = new Point(3, 3);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(327, 576);
            LeftPanel.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(189, 260);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 27;
            label5.Text = "1 - 3 мм";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(189, 206);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 26;
            label4.Text = "1 - 10 мм";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(189, 152);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 25;
            label3.Text = "20 - 50 мм";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 98);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 24;
            label2.Text = "20 - 50";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 23;
            label1.Text = "50 - 200 мм";
            // 
            // BuildButton
            // 
            BuildButton.Location = new Point(9, 524);
            BuildButton.Name = "BuildButton";
            BuildButton.Size = new Size(96, 43);
            BuildButton.TabIndex = 22;
            BuildButton.Text = "Построить";
            BuildButton.UseVisualStyleBackColor = true;
            BuildButton.Click += BuildButton_Click;
            // 
            // WidthOfTeethTextBox
            // 
            WidthOfTeethTextBox.Location = new Point(9, 257);
            WidthOfTeethTextBox.Name = "WidthOfTeethTextBox";
            WidthOfTeethTextBox.Size = new Size(175, 23);
            WidthOfTeethTextBox.TabIndex = 21;
            WidthOfTeethTextBox.TextChanged += ProcessingTextChanges;
            WidthOfTeethTextBox.MouseEnter += ProcessingMouseEnters;
            // 
            // ButtonsTableLayoutPanel
            // 
            ButtonsTableLayoutPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonsTableLayoutPanel.ColumnCount = 3;
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            ButtonsTableLayoutPanel.Controls.Add(RemoveContactButton, 0, 0);
            ButtonsTableLayoutPanel.Controls.Add(EditContactButton, 0, 0);
            ButtonsTableLayoutPanel.Controls.Add(AddContactButton, 0, 0);
            ButtonsTableLayoutPanel.Location = new Point(3, 882);
            ButtonsTableLayoutPanel.Name = "ButtonsTableLayoutPanel";
            ButtonsTableLayoutPanel.RowCount = 1;
            ButtonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ButtonsTableLayoutPanel.Size = new Size(238, 41);
            ButtonsTableLayoutPanel.TabIndex = 3;
            // 
            // RemoveContactButton
            // 
            RemoveContactButton.Dock = DockStyle.Fill;
            RemoveContactButton.Location = new Point(158, 0);
            RemoveContactButton.Margin = new Padding(0);
            RemoveContactButton.Name = "RemoveContactButton";
            RemoveContactButton.Size = new Size(80, 41);
            RemoveContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            RemoveContactButton.TabIndex = 6;
            RemoveContactButton.TabStop = false;
            // 
            // EditContactButton
            // 
            EditContactButton.Dock = DockStyle.Fill;
            EditContactButton.Location = new Point(79, 0);
            EditContactButton.Margin = new Padding(0);
            EditContactButton.Name = "EditContactButton";
            EditContactButton.Size = new Size(79, 41);
            EditContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            EditContactButton.TabIndex = 5;
            EditContactButton.TabStop = false;
            // 
            // AddContactButton
            // 
            AddContactButton.Dock = DockStyle.Fill;
            AddContactButton.Location = new Point(0, 0);
            AddContactButton.Margin = new Padding(0);
            AddContactButton.Name = "AddContactButton";
            AddContactButton.Size = new Size(79, 41);
            AddContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            AddContactButton.TabIndex = 4;
            AddContactButton.TabStop = false;
            // 
            // DistanceBetweenTeethTextBox
            // 
            DistanceBetweenTeethTextBox.Location = new Point(9, 203);
            DistanceBetweenTeethTextBox.Name = "DistanceBetweenTeethTextBox";
            DistanceBetweenTeethTextBox.Size = new Size(175, 23);
            DistanceBetweenTeethTextBox.TabIndex = 20;
            DistanceBetweenTeethTextBox.TextChanged += ProcessingTextChanges;
            DistanceBetweenTeethTextBox.MouseEnter += ProcessingMouseEnters;
            // 
            // LengthOfTeethTextBox
            // 
            LengthOfTeethTextBox.Location = new Point(9, 149);
            LengthOfTeethTextBox.Name = "LengthOfTeethTextBox";
            LengthOfTeethTextBox.Size = new Size(175, 23);
            LengthOfTeethTextBox.TabIndex = 19;
            LengthOfTeethTextBox.TextChanged += ProcessingTextChanges;
            LengthOfTeethTextBox.MouseEnter += ProcessingMouseEnters;
            // 
            // FullNameLabel
            // 
            FullNameLabel.AutoSize = true;
            FullNameLabel.Location = new Point(9, 21);
            FullNameLabel.Name = "FullNameLabel";
            FullNameLabel.Size = new Size(90, 15);
            FullNameLabel.TabIndex = 12;
            FullNameLabel.Text = "Длина ручки H";
            // 
            // NumberOfTeethTextBox
            // 
            NumberOfTeethTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumberOfTeethTextBox.BackColor = SystemColors.Window;
            NumberOfTeethTextBox.Location = new Point(9, 95);
            NumberOfTeethTextBox.Name = "NumberOfTeethTextBox";
            NumberOfTeethTextBox.Size = new Size(174, 23);
            NumberOfTeethTextBox.TabIndex = 18;
            NumberOfTeethTextBox.TextChanged += ProcessingTextChanges;
            NumberOfTeethTextBox.MouseEnter += ProcessingMouseEnters;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(9, 75);
            EmailLabel.Margin = new Padding(3, 10, 3, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(93, 15);
            EmailLabel.TabIndex = 13;
            EmailLabel.Text = "Число зубцов n";
            // 
            // HandleLengthTextBox
            // 
            HandleLengthTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HandleLengthTextBox.Location = new Point(9, 39);
            HandleLengthTextBox.Name = "HandleLengthTextBox";
            HandleLengthTextBox.Size = new Size(174, 23);
            HandleLengthTextBox.TabIndex = 17;
            HandleLengthTextBox.TextChanged += ProcessingTextChanges;
            HandleLengthTextBox.MouseEnter += ProcessingMouseEnters;
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(9, 131);
            PhoneNumberLabel.Margin = new Padding(3, 10, 3, 0);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(93, 15);
            PhoneNumberLabel.TabIndex = 14;
            PhoneNumberLabel.Text = "Длина зубьев w";
            // 
            // VKLable
            // 
            VKLable.AutoSize = true;
            VKLable.Location = new Point(9, 239);
            VKLable.Margin = new Padding(3, 10, 3, 0);
            VKLable.Name = "VKLable";
            VKLable.Size = new Size(103, 15);
            VKLable.TabIndex = 16;
            VKLable.Text = "Ширина зубьев l2";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Location = new Point(9, 185);
            DateOfBirthLabel.Margin = new Padding(3, 10, 3, 0);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(170, 15);
            DateOfBirthLabel.TabIndex = 15;
            DateOfBirthLabel.Text = "Расстояние между зубьями l1";
            // 
            // MainTableLayoutPanel
            // 
            MainTableLayoutPanel.ColumnCount = 2;
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 333F));
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Controls.Add(LeftPanel, 0, 0);
            MainTableLayoutPanel.Controls.Add(RightPanel, 1, 0);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 1;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(632, 582);
            MainTableLayoutPanel.TabIndex = 1;
            // 
            // RightPanel
            // 
            RightPanel.Controls.Add(HairbrushPictureBox);
            RightPanel.Controls.Add(BirthdayPanel);
            RightPanel.Dock = DockStyle.Fill;
            RightPanel.Location = new Point(336, 3);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(293, 576);
            RightPanel.TabIndex = 1;
            // 
            // HairbrushPictureBox
            // 
            HairbrushPictureBox.Dock = DockStyle.Fill;
            HairbrushPictureBox.Image = View.Properties.Resources.Hairbrush;
            HairbrushPictureBox.InitialImage = (Image)resources.GetObject("HairbrushPictureBox.InitialImage");
            HairbrushPictureBox.Location = new Point(0, 0);
            HairbrushPictureBox.Name = "HairbrushPictureBox";
            HairbrushPictureBox.Size = new Size(293, 576);
            HairbrushPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            HairbrushPictureBox.TabIndex = 12;
            HairbrushPictureBox.TabStop = false;
            // 
            // BirthdayPanel
            // 
            BirthdayPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BirthdayPanel.BackColor = Color.FromArgb(245, 245, 255);
            BirthdayPanel.Controls.Add(BirthdayPanelCloseButton);
            BirthdayPanel.Controls.Add(BirthdaySurnamesLabel);
            BirthdayPanel.Controls.Add(BirthdayLabel);
            BirthdayPanel.Controls.Add(BirthdayPanelPictureBox);
            BirthdayPanel.Location = new Point(3, 842);
            BirthdayPanel.Name = "BirthdayPanel";
            BirthdayPanel.Size = new Size(632, 81);
            BirthdayPanel.TabIndex = 11;
            // 
            // BirthdayPanelCloseButton
            // 
            BirthdayPanelCloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BirthdayPanelCloseButton.Location = new Point(936, 3);
            BirthdayPanelCloseButton.Margin = new Padding(0);
            BirthdayPanelCloseButton.Name = "BirthdayPanelCloseButton";
            BirthdayPanelCloseButton.Size = new Size(32, 32);
            BirthdayPanelCloseButton.SizeMode = PictureBoxSizeMode.CenterImage;
            BirthdayPanelCloseButton.TabIndex = 7;
            BirthdayPanelCloseButton.TabStop = false;
            // 
            // BirthdaySurnamesLabel
            // 
            BirthdaySurnamesLabel.AutoSize = true;
            BirthdaySurnamesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BirthdaySurnamesLabel.ForeColor = Color.FromArgb(0, 144, 255);
            BirthdaySurnamesLabel.Location = new Point(68, 42);
            BirthdaySurnamesLabel.Name = "BirthdaySurnamesLabel";
            BirthdaySurnamesLabel.Size = new Size(0, 15);
            BirthdaySurnamesLabel.TabIndex = 2;
            // 
            // BirthdayLabel
            // 
            BirthdayLabel.AutoSize = true;
            BirthdayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BirthdayLabel.ForeColor = Color.FromArgb(0, 144, 255);
            BirthdayLabel.Location = new Point(68, 23);
            BirthdayLabel.Name = "BirthdayLabel";
            BirthdayLabel.Size = new Size(118, 15);
            BirthdayLabel.TabIndex = 1;
            BirthdayLabel.Text = "Today is Birthday of:";
            // 
            // BirthdayPanelPictureBox
            // 
            BirthdayPanelPictureBox.Location = new Point(9, 5);
            BirthdayPanelPictureBox.Name = "BirthdayPanelPictureBox";
            BirthdayPanelPictureBox.Size = new Size(59, 66);
            BirthdayPanelPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            BirthdayPanelPictureBox.TabIndex = 0;
            BirthdayPanelPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(632, 582);
            Controls.Add(MainTableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Расческа";
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            ButtonsTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RemoveContactButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EditContactButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddContactButton).EndInit();
            MainTableLayoutPanel.ResumeLayout(false);
            RightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HairbrushPictureBox).EndInit();
            BirthdayPanel.ResumeLayout(false);
            BirthdayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BirthdayPanelCloseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)BirthdayPanelPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel LeftPanel;
        private TextBox WidthOfTeethTextBox;
        private TableLayoutPanel ButtonsTableLayoutPanel;
        private PictureBox RemoveContactButton;
        private PictureBox EditContactButton;
        private PictureBox AddContactButton;
        private TextBox DistanceBetweenTeethTextBox;
        private TextBox LengthOfTeethTextBox;
        private Label FullNameLabel;
        private TextBox NumberOfTeethTextBox;
        private Label EmailLabel;
        private TextBox HandleLengthTextBox;
        private Label PhoneNumberLabel;
        private Label VKLable;
        private Label DateOfBirthLabel;
        private TableLayoutPanel MainTableLayoutPanel;
        private Panel RightPanel;
        private PictureBox HairbrushPictureBox;
        private Panel BirthdayPanel;
        private PictureBox BirthdayPanelCloseButton;
        private Label BirthdaySurnamesLabel;
        private Label BirthdayLabel;
        private PictureBox BirthdayPanelPictureBox;
        private Button BuildButton;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}