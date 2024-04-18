using Shutdown_8;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ShutdownLibrary
{
    public class ShutdownManager
    {
        private System.Timers.Timer countdownTimer;
        private int countdownSeconds;
        private Label statusLabel;
        private RadioButton shutdownRadioButton;
        private RadioButton hibernateRadioButton;
        private RadioButton netflixRadioButton;
        private TextBox timeTextBox;
        private Button startButton;
        private Button stopButton;
        private RadioButton formatRadioButton;
        private RadioButton selectedHourRadioButton;
        private bool countdownStarted = false;

        public ShutdownManager(Label statusLabel, RadioButton shutdownRadioButton, RadioButton hibernateRadioButton, RadioButton netflixRadioButton, TextBox timeTextBox, Button startButton, Button stopButton, RadioButton formatRadioButton, RadioButton selectedHourRadioButton)
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
            AttachEventHandlers();
        }

        private void InitializeCountdownTimer()
        {
            countdownTimer = new System.Timers.Timer(1000);
            countdownTimer.Elapsed += CountdownTimer_Tick;
        }

        private void AttachEventHandlers()
        {
            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Sprawdzenie, czy jakaś opcja została wybrana
                if (!shutdownRadioButton.Checked && !hibernateRadioButton.Checked && !netflixRadioButton.Checked)
                {
                    ShowErrorMessage("Proszę wybrać jedną z opcji: Shutdown, Hibernate lub Netflix.");
                    return; // Przerwij działanie metody, jeśli żadna opcja nie została wybrana
                }

                if (selectedHourRadioButton.Checked)
                {
                    string[] timeParts = timeTextBox.Text.Split(':');

                    if (timeParts.Length != 2)
                    {
                        ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm.");
                        return;
                    }

                    int targetHour, targetMinute;

                    if (!int.TryParse(timeParts[0], out targetHour) || !int.TryParse(timeParts[1], out targetMinute))
                    {
                        ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm.");
                        return;
                    }

                    // Sprawdzenie poprawności wprowadzonej godziny i minuty
                    if (targetHour < 0 || targetHour > 23 || targetMinute < 0 || targetMinute > 59)
                    {
                        ShowErrorMessage("Nieprawidłowa godzina lub minuta.");
                        return;
                    }

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
                countdownStarted = true; // Ustawiamy flagę na true, aby oznaczyć rozpoczęcie odliczania
                DisableRadioButtons(); // Wyłączamy przyciski radiowe

                countdownTimer.Start();
            }
            catch (FormatException)
            {
                ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm.");
            }
        }



        private void StopButton_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            UpdateStatusLabel("Odliczanie zatrzymane.");

            countdownStarted = false; // Po zatrzymaniu odliczania ustawiamy flagę z powrotem na false
            EnableRadioButtons(); // Odblokowujemy przyciski radiowe
        }

        private int ParseTimeInSeconds()
        {
            string timeText = timeTextBox.Text;
            int hours = 0, minutes = 0, seconds = 0;

            // Sprawdź, czy tekst zawiera dwukropki
            if (timeText.Contains(":"))
            {
                // Podziel tekst na części przed i po dwukropku
                string[] timeParts = timeText.Split(':');

                // Sprawdź, czy podano odpowiednią liczbę części czasu
                if (timeParts.Length == 2 || timeParts.Length == 3)
                {
                    // Obsługa formatu mm:ss
                    if (timeParts.Length == 2)
                    {
                        if (!int.TryParse(timeParts[0], out minutes) || !int.TryParse(timeParts[1], out seconds))
                        {
                            ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm:ss lub mm:ss lub ss.");
                            return 0;
                        }
                    }
                    // Obsługa formatu hh:mm:ss
                    else if (timeParts.Length == 3)
                    {
                        if (!int.TryParse(timeParts[0], out hours) || !int.TryParse(timeParts[1], out minutes) || !int.TryParse(timeParts[2], out seconds))
                        {
                            ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm:ss lub mm:ss lub ss.");
                            return 0;
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm:ss lub mm:ss lub ss.");
                    return 0;
                }
            }
            // Jeśli nie ma dwukropków
            else
            {
                // Obsługa formatu ss
                if (!int.TryParse(timeText, out seconds))
                {
                    ShowErrorMessage("Nieprawidłowy format czasu. Wprowadź czas w formacie hh:mm:ss lub mm:ss lub ss.");
                    return 0;
                }
            }

            // Sprawdź poprawność wartości
            if (hours < 0 || minutes < 0 || seconds < 0 || minutes >= 60 || seconds >= 60)
            {
                ShowErrorMessage("Nieprawidłowy czas. Wprowadź czas w formacie hh:mm:ss lub mm:ss, gdzie mm i ss to liczby od 0 do 59.");
                return 0;
            }

            // Zwróć czas w sekundach
            return hours * 3600 + minutes * 60 + seconds;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
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

        private void UpdateRemainingTimeStatusLabel()
        {
            string mode = GetSelectedMode();
            TimeSpan remainingTime = TimeSpan.FromSeconds(countdownSeconds);
            UpdateStatusLabel($"{mode} nastąpi za: \n {FormatTime(remainingTime)}");
        }

        private void ExecuteAction()
        {
            string mode = GetSelectedMode();
            if (shutdownRadioButton.Checked)
            {
                ShutdownComputer();
                UpdateStatusLabel($"Akcja wykonana. \n Komputer zostanie wyłączony");
            }
            else if (hibernateRadioButton.Checked)
            {
                HibernateComputer();
                UpdateStatusLabel($"Akcja wykonana. \n Komputer zostanie zahibernowany");
            }
            else if (netflixRadioButton.Checked)
            {
                ShutdownNetflix();
                UpdateStatusLabel($"Akcja wykonana. \n Aplikacja Netflix zostanie zamknięta.");
            }
            else
            {
                UpdateStatusLabel("Żadna akcja nie została wybrana.");
            }

            countdownTimer.Stop();
        }

        private string GetSelectedMode()
        {
            if (shutdownRadioButton.Checked)
            {
                return "Zamknięcie systemu";
            }
            else if (hibernateRadioButton.Checked)
            {
                return "Hibernacja systemu";
            }
            else if (netflixRadioButton.Checked)
            {
                return "Zamknięcie aplikacji Netflix";
            }
            else
            {
                return "Nieznana akcja";
            }
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            if (timeSpan.Hours > 0)
            {
                return $"{timeSpan.Hours} godzin {timeSpan.Minutes} minut {timeSpan.Seconds} sekund";
            }
            else if (timeSpan.Minutes > 0)
            {
                return $"{timeSpan.Minutes} minut {timeSpan.Seconds} sekund";
            }
            else
            {
                return $"{timeSpan.Seconds} sekund";
            }
        }

        private void ShutdownComputer()
        {
            Process.Start("shutdown", "/s /f /t 1");
        }

        private void HibernateComputer()
        {
            Process.Start("shutdown", "/h");
        }

        private void ShutdownNetflix()
        {
            Process.Start("taskkill", "/IM ApplicationFrameHost.exe");
        }

        private void UpdateStatusLabel(string message)
        {
            if (statusLabel.InvokeRequired)
            {
                statusLabel.Invoke(new Action<string>(UpdateStatusLabel), message);
            }
            else
            {
                statusLabel.Text = message;
            }
        }

        // Metoda do blokowania przycisków radiowych
        private void DisableRadioButtons()
        {
            selectedHourRadioButton.Enabled = false;
            formatRadioButton.Enabled = false;
        }

        // Metoda do odblokowywania przycisków radiowych
        private void EnableRadioButtons()
        {
            selectedHourRadioButton.Enabled = true;
            formatRadioButton.Enabled = true;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Planner Akcji - Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

