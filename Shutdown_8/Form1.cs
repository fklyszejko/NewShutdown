using ShutdownLibrary;

namespace Shutdown_8
{
    public partial class Form1 : Form
    {
        private ShutdownManager shutdownManager;

        public Form1()
        {
            InitializeComponent();
            shutdownManager = new ShutdownManager(statusLabel, shutdownRadioButton, hibernateRadioButton, netflixRadioButton, timeTextBox, startButton, stopButton, formatRadioButton, timerRadioButton);
        }

        private string InsertColon(string text, int position)
        {
            // Wstaw separator ":" w odpowiednim miejscu
            return text.Insert(position, ":");
        }

        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = timeTextBox.Text;

            // Zapami�taj aktualn� pozycj� kursora
            int cursorPosition = timeTextBox.SelectionStart;

            if (formatRadioButton.Checked)
            {
                timeTextBox.MaxLength = 8;
            }
            else if (timerRadioButton.Checked)
            {
                timeTextBox.MaxLength = 5;
            }

            // Sprawd�, czy tekst zawiera wi�cej ni� 1 cyfr�
            if (text.Length > 1)
            {
                // Dodaj dwukropek po drugiej cyfrze, je�li d�ugo�� tekstu wynosi 3 i nie zawiera dwukropka
                if (text.Length == 3 && !text.Contains(":"))
                {
                    timeTextBox.Text = InsertColon(text, 2);
                    // Przywr�� pozycj� kursora
                    timeTextBox.SelectionStart = cursorPosition + 1;
                }
                // Dodaj dwukropek po czwartej cyfrze, je�li d�ugo�� tekstu wynosi 5 i nie zawiera dwukropka
                else if (text.Length == 6)
                {
                    timeTextBox.Text = InsertColon(text, 5);
                    // Przywr�� pozycj� kursora
                    timeTextBox.SelectionStart = cursorPosition + 1;
                }
            }
        }
    }
}