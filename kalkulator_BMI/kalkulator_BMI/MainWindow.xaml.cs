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

namespace kalkulator_BMI
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

        private void ObliczBMI_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(txtWzrost.Text) || string.IsNullOrWhiteSpace(txtWaga.Text))
                {
                    MessageBox.Show("Proszę wprowadzić wzrost i wagę.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                
                if (!double.TryParse(txtWzrost.Text, out double wzrostCm) ||
                    !double.TryParse(txtWaga.Text, out double waga))
                {
                    MessageBox.Show("Proszę wprowadzić poprawne wartości liczbowe.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                
                double wzrostM = wzrostCm / 100;

                
                double bmi = waga / (wzrostM * wzrostM);
                string kategoria;

                
                if (bmi < 18.5)
                    kategoria = "Niedowaga";
                else if (bmi < 25)
                    kategoria = "Prawidłowa masa ciała";
                else if (bmi < 30)
                    kategoria = "Nadwaga";
                else
                    kategoria = "Otyłość";

                
                txtWynik.Text = $"Twoje BMI: {bmi:F2}\nKategoria: {kategoria}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}