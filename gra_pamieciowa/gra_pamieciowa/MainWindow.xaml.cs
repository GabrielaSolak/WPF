using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gra_pamieciowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> words;
        private List<string> sequence;
        private int score;
        private Random random;

        public MainWindow()
        {
            InitializeComponent();
            words = new List<string> { "jabłko", "gruszka", "pomarańcza", "banan", "truskawka" };
            sequence = new List<string>();
            score = 0;
            random = new Random();
            UpdateScore();
        }

        private void DrawWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Brak słów do losowania. Restartuj grę.");
                return;
            }

            int index = random.Next(words.Count);
            string word = words[index];
            words.RemoveAt(index);

            sequence.Add(word);
            currentWordText.Text = word;
            userInputTextBox.Clear();
        }

        private void CheckAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string userAnswer = userInputTextBox.Text.Trim();
            string correctAnswer = string.Join(" ", sequence);

            if (userAnswer == correctAnswer)
            {
                score++;
                feedbackText.Text = "Poprawna odpowiedź!";
            }
            else
            {
                feedbackText.Text = $"Niepoprawna odpowiedź! Poprawna: {correctAnswer}";

                MessageBox.Show("Koniec gry. Twoje punkty: " + score);
                words.Clear();
            }

            UpdateScore();
        }
        private void UpdateScore()
        {
            scoreText.Text = "Punkty: " + score;
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            words = new List<string> { "jabłko", "gruszka", "pomarańcza", "banan", "truskawka" };  
            sequence.Clear();
            score = 0;
            UpdateScore();
            feedbackText.Text = string.Empty;
            currentWordText.Text = string.Empty;
        }
    }
}