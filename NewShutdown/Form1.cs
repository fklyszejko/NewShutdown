using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace NewShutdown
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer countdownTimer;
        private int countdownSeconds;

        public Form1()
        {
            InitializeComponent();
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
