using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Shutdown_8
{
    public partial class Form1 : Form
    {
        private readonly Events events;

        public Form1()
        {
            InitializeComponent();
            events = new Events(statusLabel, shutdownRadioButton,hibernateRadioButton, netflixRadioButton, timeTextBox,startButton, stopButton, formatRadioButton,timerRadioButton);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            events.StartEvent();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            events.StopEvent();
        }

        private void timeTextBox_TextChanged([AllowNull] object sender, EventArgs e)
        {
            events.timeTextBoxEvent();
        }
    }

    public class Events
    {
        private readonly System.Timers.Timer timer = new System.Timers.Timer(2000);
        private readonly System.Timers.Timer countdownTimer = new System.Timers.Timer(1000);
        private int countdownSeconds;
        private readonly Label statusLabel;
        private readonly RadioButton shutdownRadioButton;
        private readonly RadioButton hibernateRadioButton;
        private readonly RadioButton netflixRadioButton;
        private readonly TextBox timeTextBox;
        private readonly Button startButton;
        private readonly Button stopButton;
        private readonly RadioButton formatRadioButton;
        private readonly RadioButton selectedHourRadioButton;

        public Events(Label statusLabel, RadioButton shutdownRadioButton, RadioButton hibernateRadioButton,RadioButton netflixRadioButton, TextBox timeTextBox, Button startButton, Button stopButton, RadioButton formatRadioButton, RadioButton selectedHourRadioButton)
        {
            this.statusLabel = statusLabel;
            this.shutdownRadioButton = shutdownRadioButton;
            this.hibernateRadioButton = hibernateRadioButton;
            this.netflixRadioButton = netflixRadioButton;
            this.timeTextBox = timeTextBox;
            this.startButton = startButton;
            this.stopButton = stopButton;
            this.formatRadioButton = formatRadioButton;
            this.selectedHourRadioButton = selectedHourRadioButton;

            InitializeCountdownTimer();
        }
        private void InitializeCountdownTimer()
        {
            countdownTimer.Elapsed += CountdownTimer_Tick;
        }
        public void timeTextBoxEvent()
        {
            string text = timeTextBox.Text;
            // Zapamiêtaj aktualn¹ pozycjê kursora
            int cursorPosition = timeTextBox.SelectionStart;
            if (formatRadioButton.Checked)
            {
                timeTextBox.MaxLength = 8;
            }
            else if (selectedHourRadioButton.Checked)
            {
                timeTextBox.MaxLength = 5;
            }
            // SprawdŸ, czy tekst zawiera wiêcej ni¿ 1 cyfrê
            if (text.Length > 1)
            {
                // SprawdŸ, czy nie ma dwukropka w odpowiednich miejscach
                if (text.Length == 3 && text[2] != ':')
                {
                    text = text.Insert(2, ":");
                    // Przywróæ pozycjê kursora
                    timeTextBox.Text = text;
                    timeTextBox.SelectionStart = cursorPosition + 1;
                }
                else if (text.Length == 6 && text[5] != ':')
                {
                    text = text.Insert(5, ":");
                    // Przywróæ pozycjê kursora
                    timeTextBox.Text = text;
                    timeTextBox.SelectionStart = cursorPosition + 1;
                }
            }
        }
        public void StartEvent()
        {
            try
            {
                if (!shutdownRadioButton.Checked && !hibernateRadioButton.Checked && !netflixRadioButton.Checked)
                {
                    ShowErrorMessage("Proszê wybraæ jedn¹ z opcji: Shutdown, Hibernate lub Netflix.");
                        return;
                }

                // Logika dla wybranej opcji czasu
                if (selectedHourRadioButton.Checked)
                {
                    // Sprawdzenie poprawnoœci formatu czasu
                    string[] timeParts = timeTextBox.Text.Split(':');
                    if (timeParts.Length != 2)
                    {
                        ShowErrorMessage("Nieprawid³owy format czasu. WprowadŸ czas w formacie hh: mm.");
                        return;
                    }
                    // Parsowanie godziny i minuty
                    if (!int.TryParse(timeParts[0], out int targetHour)
                    || !int.TryParse(timeParts[1], out int
                    targetMinute))
                    {
                        ShowErrorMessage("Nieprawid³owy format czasu. WprowadŸ czas w formacie hh: mm.");
                        return;
                    }
                    // Sprawdzenie poprawnoœci godziny i minuty
                    if (targetHour < 0 || targetHour > 23 ||
                    targetMinute < 0 || targetMinute > 59)
                    {
                        ShowErrorMessage("Nieprawid³owa godzina lub minuta.");
                        return;
                    }
                    DateTime now = DateTime.Now;
                    DateTime targetTime = new(now.Year, now.Month, now.Day, targetHour, targetMinute, 0);
                    if (targetTime <= now)
                    {
                        targetTime = targetTime.AddDays(1);
                    }
                    countdownSeconds = (int)(targetTime - now).TotalSeconds;
                }
                else if (formatRadioButton.Checked)
                {
                    countdownSeconds = ParseTimeInSeconds();
                    if (countdownSeconds == 0)
                    {
                        return;
                    }
                }
                OffControls();
                countdownTimer.Start();
            }
            catch (FormatException)
            {
                ShowErrorMessage("Nieprawid³owy format czasu. WprowadŸ czas w formacie hh: mm.");
            }
        }
        public void StopEvent()
        {
            countdownTimer.Stop();
            UpdateStatusLabel("Odliczanie zatrzymane.");
            ResetControls();
        }
        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            if (countdownSeconds > 0)
            {
                UpdateRemainingTimeStatusLabel();
                countdownSeconds--;
            }
            else
            {
                ExecuteAction();
            }
        }
        private int ParseTimeInSeconds()
        {
            string timeText = timeTextBox.Text;
            int hours = 0, minutes = 0, seconds = 0;
            if (timeText.Contains(":"))
            {
                string[] timeParts = timeText.Split(':');
                if (timeParts.Length is 2 or 3)
                {
                    if (timeParts.Length == 2)
                    {
                        if (!int.TryParse(timeParts[0], out minutes) || !int.TryParse(timeParts[1], out seconds))
                        {
                            ShowErrorMessage("Nieprawid³owy format czasu.WprowadŸ czas w formacie hh: mm:ss lub mm: ss lub ss.");
                            return 0;
                        }
                    }

                    else if (timeParts.Length == 3)
                    {
                        if (!int.TryParse(timeParts[0], out hours) || !
                        int.TryParse(timeParts[1], out minutes) || !
                        int.TryParse(timeParts[2], out seconds))
                        {
                            ShowErrorMessage("Nieprawid³owy format czasu.WprowadŸ czas w formacie hh: mm:ss lub mm: ss lub ss.");
                            return 0;
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Nieprawid³owy format czasu. WprowadŸ czas w formacie hh: mm:ss lub mm: ss lub ss.");
                    return 0;
                }
            }
            else
            {
                if (!int.TryParse(timeText, out seconds))
                {
                    ShowErrorMessage("Nieprawid³owy format czasu.WprowadŸ czas w formacie hh:mm:ss lub mm:ss lub ss.");
                    return 0;
                }
            }

            if (hours < 0 || minutes < 0 || seconds < 0 || minutes >= 60 || seconds >= 60)
            {
                ShowErrorMessage("Nieprawid³owy czas. WprowadŸ czas w formacie hh: mm:ss lub mm: ss, gdzie mm i ss to liczby od 0 do 59.");
                return 0;
            }
            return (hours * 3600) + (minutes * 60) + seconds;
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            if (timeSpan.Hours > 0)
            {
                return $"{timeSpan.Hours} godzin {timeSpan.Minutes} minut {timeSpan.Seconds} sekund";
            }
            else
            {
                return timeSpan.Minutes > 0 ? $"{timeSpan.Minutes} minut {timeSpan.Seconds} sekund" : $"{timeSpan.Seconds} sekund";
            }
        }
        private void UpdateRemainingTimeStatusLabel()
        {
            string mode = GetSelectedMode();
            TimeSpan remainingTime = TimeSpan.FromSeconds(countdownSeconds);
            UpdateStatusLabel($"{mode} nast¹pi za:\n{FormatTime(remainingTime)}");
        }
        private void ShowErrorMessage(string message)
        {
            _ = MessageBox.Show(message, "Planner Akcji - B³¹d",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void UpdateStatusLabel(string message)
        {
            if (statusLabel.InvokeRequired)
            {
                _ = statusLabel.Invoke(new Action<string> (UpdateStatusLabel), message);
            }
            else
            {
                statusLabel.Text = message;
            }
        }
        private void labelTimer()
        {
            timer.Start();
            timer.Elapsed += (sender, e) =>
            {
                UpdateStatusLabel("");
                timer.Stop();
            };
            if (statusLabel.InvokeRequired)
            {
                statusLabel.Invoke(new Action(labelTimer));
            }
            else
            {
                timeTextBox.Clear();
                ResetControls();
            }
        }
        private void ExecuteAction()
        {
            _ = GetSelectedMode();
            if (shutdownRadioButton.Checked)
            {
                ShutdownComputer();
                UpdateStatusLabel($"Akcja wykonana.\nKomputer zostanie wy³¹czony");
            }
            else if (hibernateRadioButton.Checked)
            {
                HibernateComputer();
                UpdateStatusLabel($"Akcja wykonana.\nKomputer zostanie zahibernowany");
                Application.Exit();
            }
            else if (netflixRadioButton.Checked)
            {
                ShutdownNetflix();
                UpdateStatusLabel($"Akcja wykonana.\nAplikacja Netflix zostanie zamkniêta.");
            }
            else
            {
                UpdateStatusLabel("¯adna akcja nie zosta³a wybrana.");
            }
            countdownTimer.Stop();
            labelTimer();
        }
        private string GetSelectedMode()
        {
            if (shutdownRadioButton.Checked)
            {
                return "Zamkniêcie systemu";
            }
            else if (hibernateRadioButton.Checked)
            {
                return "Hibernacja systemu";
            }
            else
            {
                return netflixRadioButton.Checked ? "Zamkniêcie aplikacji Netflix" : "Nieznana akcja";
            }
        }
        private void OffControls()
        {
            selectedHourRadioButton.Enabled = false;
            formatRadioButton.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }
        private void ResetControls()
        {
            selectedHourRadioButton.Enabled = true;
            formatRadioButton.Enabled = true;
            stopButton.Enabled = false;
            startButton.Enabled = true;
        }
        private void ShutdownComputer()
        {
            _ = Process.Start("shutdown", "/s /f /t 1");
        }
        private void HibernateComputer()
        {
            _ = Process.Start("shutdown", "/h");
        }
        private void ShutdownNetflix()
        {
            _ = Process.Start("taskkill", "/IM ApplicationFrameHost.exe");
        }
    }
}