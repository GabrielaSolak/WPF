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
                if (string.IsNullOrWhiteSpace(txtWaga.Text) || string.IsNullOrWhiteSpace(txtWzrost.Text))
                {
                    MessageBox.Show("Proszę wprowadzić wagę i wzrost.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!double.TryParse(txtWaga.Text, out double waga) ||
                    !double.TryParse(txtWzrost.Text, out double wzrost))
                {
                    MessageBox.Show("Proszę wprowadzić poprawne liczby.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                

                string jednostkaWagi = ((ComboBoxItem)cmbWagaJednostka.SelectedItem).Content.ToString();
                string jednostkaWzrostu = ((ComboBoxItem)cmbWzrostJednostka.SelectedItem).Content.ToString();

                double wagaKg = 0;
                double wzrostM = 0;

                if ((jednostkaWzrostu == "stopy" || jednostkaWzrostu == "cale") && jednostkaWagi != "funty")
                {
                    MessageBox.Show("Podaj wagę w funtach, jeśli wybrałeś wzrost w stopach lub calach.", "Błąd jednostek", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (jednostkaWzrostu == "cm" && jednostkaWagi != "kg")
                {
                    MessageBox.Show("Podaj wagę w kilogramach, jeśli wybrałeś wzrost w centymetrach.", "Błąd jednostek", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                switch (jednostkaWagi)
                {
                    case "kg":
                        wagaKg = waga;
                        break;
                    case "funty":
                        wagaKg = waga * 0.45359237;
                        break;
                }

                switch (jednostkaWzrostu)
                {
                    case "cm":
                        wzrostM = wzrost / 100;
                        break;
                    case "cale":
                        wzrostM = wzrost * 0.0254;
                        break;
                    case "stopy":
                        wzrostM = wzrost * 0.3048;
                        break;
                }


                if (wagaKg < 25 || wagaKg > 200)
                {
                    MessageBox.Show("Nieprawidłowa waga (25-200 kg)", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (wzrostM < 1 || wzrostM > 2.5)
                {
                    MessageBox.Show("Nieprawidłowa wzrost (100-250 cm)", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                double bmi = wagaKg / (wzrostM * wzrostM);

                string kategoria;
                string opis;
                if (bmi < 18.5)
                { 
                    kategoria = "Niedowaga";
                    opis = "Postaraj się jeść więcej.";
                }
                else if (bmi < 25)
                { 
                    kategoria = "Prawidłowa masa ciała";
                    opis = "Trzymaj tak dalej, pamiętaj o systematycznych ćwiczeniach by utrzymać organizm w formie.";
                }
                else if (bmi < 30)
                { 
                    kategoria = "Nadwaga";
                    opis = "Postaraj się ograniczyć spożywane kalorie.";
                }
                else
                { 
                    kategoria = "Otyłość";
                    opis = "Ogranicz spożywane cykry i tłuszcze.";
                }

                txtWynik.Text = $"Twoje BMI: {bmi:F2}\nKategoria: {kategoria}\nOpis: {opis}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
