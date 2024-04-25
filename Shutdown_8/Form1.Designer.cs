namespace Shutdown_8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            timeTextBox = new TextBox();
            label1 = new Label();
            timerRadioButton = new RadioButton();
            formatRadioButton = new RadioButton();
            groupBox2 = new GroupBox();
            stopButton = new Button();
            startButton = new Button();
            statusLabel = new Label();
            netflixRadioButton = new RadioButton();
            hibernateRadioButton = new RadioButton();
            shutdownRadioButton = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(timeTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(timerRadioButton);
            groupBox1.Controls.Add(formatRadioButton);
            groupBox1.Location = new Point(1, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Format Czasu";
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(108, 89);
            timeTextBox.MaxLength = 8;
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(100, 23);
            timeTextBox.TabIndex = 2;
            timeTextBox.TextChanged += timeTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 61);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 15;
            label1.Text = "Czas w Formacie";
            // 
            // timerRadioButton
            // 
            timerRadioButton.AutoSize = true;
            timerRadioButton.Location = new Point(172, 22);
            timerRadioButton.Name = "timerRadioButton";
            timerRadioButton.Size = new Size(55, 19);
            timerRadioButton.TabIndex = 1;
            timerRadioButton.TabStop = true;
            timerRadioButton.Text = "Zegar";
            timerRadioButton.UseVisualStyleBackColor = true;
            // 
            // formatRadioButton
            // 
            formatRadioButton.AutoSize = true;
            formatRadioButton.Checked = true;
            formatRadioButton.Location = new Point(11, 22);
            formatRadioButton.Name = "formatRadioButton";
            formatRadioButton.Size = new Size(73, 19);
            formatRadioButton.TabIndex = 0;
            formatRadioButton.TabStop = true;
            formatRadioButton.Text = "Minutnik";
            formatRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(stopButton);
            groupBox2.Controls.Add(startButton);
            groupBox2.Controls.Add(statusLabel);
            groupBox2.Controls.Add(netflixRadioButton);
            groupBox2.Controls.Add(hibernateRadioButton);
            groupBox2.Controls.Add(shutdownRadioButton);
            groupBox2.Location = new Point(1, 133);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(317, 127);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Akcja";
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(161, 99);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 5;
            stopButton.Text = "Sto&p";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(80, 99);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 4;
            startButton.Text = "&Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AllowDrop = true;
            statusLabel.BorderStyle = BorderStyle.FixedSingle;
            statusLabel.Location = new Point(12, 58);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(290, 38);
            statusLabel.TabIndex = 10;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // netflixRadioButton
            // 
            netflixRadioButton.AutoSize = true;
            netflixRadioButton.Location = new Point(190, 22);
            netflixRadioButton.Name = "netflixRadioButton";
            netflixRadioButton.Size = new Size(60, 19);
            netflixRadioButton.TabIndex = 3;
            netflixRadioButton.TabStop = true;
            netflixRadioButton.Text = "&Netflix";
            netflixRadioButton.UseVisualStyleBackColor = true;
            // 
            // hibernateRadioButton
            // 
            hibernateRadioButton.AutoSize = true;
            hibernateRadioButton.Location = new Point(111, 22);
            hibernateRadioButton.Name = "hibernateRadioButton";
            hibernateRadioButton.Size = new Size(71, 19);
            hibernateRadioButton.TabIndex = 1;
            hibernateRadioButton.TabStop = true;
            hibernateRadioButton.Text = "&Hibernuj";
            hibernateRadioButton.UseVisualStyleBackColor = true;
            // 
            // shutdownRadioButton
            // 
            shutdownRadioButton.AutoSize = true;
            shutdownRadioButton.Location = new Point(26, 22);
            shutdownRadioButton.Name = "shutdownRadioButton";
            shutdownRadioButton.Size = new Size(68, 19);
            shutdownRadioButton.TabIndex = 0;
            shutdownRadioButton.TabStop = true;
            shutdownRadioButton.Text = "&Zamknij";
            shutdownRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(314, 263);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Planner Akcji";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private RadioButton timerRadioButton;
        private RadioButton formatRadioButton;
        private TextBox timeTextBox;
        private GroupBox groupBox2;
        private RadioButton netflixRadioButton;
        private RadioButton hibernateRadioButton;
        private RadioButton shutdownRadioButton;
        private Button stopButton;
        private Button startButton;
        private Label statusLabel;
    }
}
