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
            groupBox1 = new GroupBox();
            minutesTextBox = new TextBox();
            hourTextBox = new TextBox();
            timeTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            selectedHourRadioButton = new RadioButton();
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
            groupBox1.Controls.Add(minutesTextBox);
            groupBox1.Controls.Add(hourTextBox);
            groupBox1.Controls.Add(timeTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(selectedHourRadioButton);
            groupBox1.Controls.Add(formatRadioButton);
            groupBox1.Location = new Point(1, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Format Czasu";
            // 
            // minutesTextBox
            // 
            minutesTextBox.Enabled = false;
            minutesTextBox.Location = new Point(236, 89);
            minutesTextBox.Name = "minutesTextBox";
            minutesTextBox.Size = new Size(66, 23);
            minutesTextBox.TabIndex = 4;
            // 
            // hourTextBox
            // 
            hourTextBox.Enabled = false;
            hourTextBox.Location = new Point(159, 89);
            hourTextBox.Name = "hourTextBox";
            hourTextBox.Size = new Size(66, 23);
            hourTextBox.TabIndex = 3;
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(11, 89);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(100, 23);
            timeTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 61);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 16;
            label2.Text = "Godzina zamknięcia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 61);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 15;
            label1.Text = "Czas w Formacie";
            // 
            // selectedHourRadioButton
            // 
            selectedHourRadioButton.AutoSize = true;
            selectedHourRadioButton.Location = new Point(172, 22);
            selectedHourRadioButton.Name = "selectedHourRadioButton";
            selectedHourRadioButton.Size = new Size(113, 19);
            selectedHourRadioButton.TabIndex = 1;
            selectedHourRadioButton.TabStop = true;
            selectedHourRadioButton.Text = "Wybierz Godzinę";
            selectedHourRadioButton.UseVisualStyleBackColor = true;
            selectedHourRadioButton.CheckedChanged += selectedHourRadioButton_CheckedChanged;
            // 
            // formatRadioButton
            // 
            formatRadioButton.AutoSize = true;
            formatRadioButton.Checked = true;
            formatRadioButton.Location = new Point(11, 22);
            formatRadioButton.Name = "formatRadioButton";
            formatRadioButton.Size = new Size(144, 19);
            formatRadioButton.TabIndex = 0;
            formatRadioButton.TabStop = true;
            formatRadioButton.Text = "hh:mm:ss / mm:ss / ss";
            formatRadioButton.UseVisualStyleBackColor = true;
            formatRadioButton.CheckedChanged += formatRadioButton_CheckedChanged;
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
            ClientSize = new Size(314, 263);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Shutdown";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private RadioButton selectedHourRadioButton;
        private RadioButton formatRadioButton;
        private Label label2;
        private TextBox hourTextBox;
        private TextBox timeTextBox;
        private TextBox minutesTextBox;
        private GroupBox groupBox2;
        private RadioButton netflixRadioButton;
        private RadioButton hibernateRadioButton;
        private RadioButton shutdownRadioButton;
        private Button stopButton;
        private Button startButton;
        private Label statusLabel;
    }
}
