using System.Diagnostics;

namespace Shutdown_8
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer countdownTimer;
        private int countdownSeconds;

        public Form1()
        {
            InitializeComponent();
        }

        private void formatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            minutesTextBox.Enabled = false;
            hourTextBox.Enabled = false;
            timeTextBox.Enabled = true;
        }

        private void selectedHourRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            timeTextBox.Enabled = false;
            minutesTextBox.Enabled = true;
            hourTextBox.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            try
            {
                InitializeCountdownTimer();

                if (selectedHourRadioButton.Checked)
                {
                    int targetHour = int.Parse(hourTextBox.Text);
                    int targetMinute = int.Parse(minutesTextBox.Text);

                    DateTime now = DateTime.Now;
                    DateTime targetTime = new DateTime(now.Year, now.Month, now.Day, targetHour, targetMinute, 0);

                    if (targetTime <= now)
                    {
                        targetTime = targetTime.AddDays(1);
                    }

                    countdownSeconds = (int)(targetTime - now).TotalSeconds;


                }
                else if (formatRadioButton.Checked)
                {
                    countdownSeconds = ParseTimeInSeconds();
                }

                countdownTimer.Start();
            }

            catch (FormatException)
            {
                MessageBox.Show("Wprowad� prawid�owo sformatowany czas.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            UpdateStatusLabel("Odliczanie zatrzymane.");
        }
        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            if (countdownSeconds > 0)
            {
                UpdateStatusLabel($"Rozpocz�to odliczanie: {countdownSeconds} sekund");
                countdownSeconds--;
            }
            else
            {
                if (shutdownRadioButton.Checked)
                {
                    ShutdownComputer();
                    UpdateStatusLabel("Akcja wykonana. \n Komputer zostanie wy��czony");
                }
                else if (hibernateRadioButton.Checked)
                {
                    HibernateComputer();
                    UpdateStatusLabel("Akcja wykonana. \n Komputer zostanie zahibernowany");
                }
                else if (netflixRadioButton.Checked)
                {
                    ShutdownNetflix();
                    UpdateStatusLabel("Akcja wykonana. \n Aplikacja Netflix zostanie zamkni�ta.");
                }
                else
                {
                    UpdateStatusLabel("�adna akcja nie zosta�a wybrana.");
                }

                countdownTimer.Stop();
            }
        }
        private void InitializeCountdownTimer()
        {
            if (countdownTimer == null)
            {
                countdownTimer = new System.Timers.Timer(1000);
                countdownTimer.Elapsed += CountdownTimer_Tick;
            }
        }

        private bool IsValidTimeFormat(string time)
        {
            return !string.IsNullOrEmpty(time);
        }

        private int ParseTimeInSeconds()
        {
            if (formatRadioButton.Checked)
            {
                string timeText = timeTextBox.Text;

                // Sprawd�, czy tekst zawiera tylko jedn� cyfr� i dodaj "0" z przodu
                if (timeText.Length == 1)
                {
                    timeText = "00:00:0" + timeText;
                }
                else if (timeText.Length == 2)
                {
                    timeText = "00:00:" + timeText;
                }

                if (TimeSpan.TryParse(timeText, out TimeSpan timeSpan))
                {
                    return (int)timeSpan.TotalSeconds;
                }
            }
            else
            {
                int minutes = int.Parse(minutesTextBox.Text);
                int hours = int.Parse(hourTextBox.Text);
                return (hours * 60 + minutes) * 60;
            }

            return 0;
        }

        private void ShutdownComputer()
        {
            // Process.Start("shutdown", "/s /f /t 1");
        }

        private void HibernateComputer()
        {
            // Process.Start("shutdown", "/h");
        }

        private void ShutdownNetflix()
        {
            Process.Start("taskkill", "/IM ApplicationFrameHost.exe");
        }

        private void UpdateStatusLabel(string message)
        {
            if (statusLabel.InvokeRequired)
            {
                // Je�li wywo�anie pochodzi z innego w�tku, u�yj Invoke, aby przenie�� si� na w�tek UI.
                statusLabel.Invoke(new Action(() => statusLabel.Text = message));
            }
            else
            {
                // Je�li jeste�my ju� na w�tku UI, mo�emy bezpo�rednio aktualizowa� kontrolk�.
                statusLabel.Text = message;
            }
        }
    }
}
