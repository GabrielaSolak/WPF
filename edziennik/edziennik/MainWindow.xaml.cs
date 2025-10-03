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

namespace edziennik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            string imie = ImieTextBox.Text.Trim();
            string nazwisko = NazwiskoTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko))
            {
                MessageBox.Show("Podaj imię i nazwisko ucznia.");
                return;
            }

            if (!double.TryParse(Test1TextBox.Text, out double test1) ||
                !double.TryParse(Test2TextBox.Text, out double test2) ||
                !double.TryParse(Test3TextBox.Text, out double test3))
            {
                MessageBox.Show("Wprowadź poprawne liczby w polach testów.");
                return;
            }

            double max1 = 50, max2 = 70, max3 = 80;

            double p1 = (test1 / max1) * 100;
            double p2 = (test2 / max2) * 100;
            double p3 = (test3 / max3) * 100;

            double srednia = (p1 + p2 + p3) / 3;

            // Wyświetlenie wyników
            UczenTextBlock.Text = $"{imie} {nazwisko}";
            Test1TextBlock.Text = $"Test 1 - {p1:F0}%";
            Test2TextBlock.Text = $"Test 2 - {p2:F0}%";
            Test3TextBlock.Text = $"Test 3 - {p3:F0}%";
            SredniaTextBlock.Text = $"Średnia: {srednia:F2}%";

            if (srednia >= 50)
            {
                InfoTextBlock.Text = "Uczeń zdał.";
            }
            else if (srednia >= 30)
            {
                InfoTextBlock.Text = "Uczeń nie zdał.";
            }
        }
    }
}