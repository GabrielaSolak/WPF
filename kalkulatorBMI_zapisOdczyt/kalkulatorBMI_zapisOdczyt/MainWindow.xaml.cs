using System.Collections.ObjectModel;
using System.IO;
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

namespace kalkulatorBMI_zapisOdczyt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private ObservableCollection<Pomiar> HistoriaPomiarow = new();
        public MainWindow()
        {
            InitializeComponent();

            HistoriaGrid.ItemsSource = HistoriaPomiarow;
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            BladText.Text = "";
            if (!int.TryParse(UserIDInput.Text, out int userId))
            {
                BladText.Text = "Podaj poprawny ID użytkownika (liczba)";
                return;
            }
            if (!double.TryParse(WagaInput.Text, out double waga) ||
                !double.TryParse(WzrostInput.Text, out double wzrost) ||
                !int.TryParse(WiekInput.Text, out int wiek))
            {
                BladText.Text = "Podaj poprawne dane";
                return;
            }

            if (PlecCombo.SelectedItem is not ComboBoxItem plecItem)
            {
                BladText.Text = "Wybierz płeć";
                return;
            }
            string plec = plecItem.Content.ToString();

            if (JednostkaWagi.SelectedItem is not ComboBoxItem itemWagi ||
                JednostkaWzrostu.SelectedItem is not ComboBoxItem itemWzrostu)
            {
                BladText.Text = "Wybierz jednostki";
                return;
            }

            string jednostkaWagi = itemWagi.Content.ToString();
            string jednostkaWzrostu = itemWzrostu.Content.ToString();

            double wagaKg = (jednostkaWagi == "Funty") ? waga * 0.453592 : waga;
            double wzrostM =
                jednostkaWzrostu == "Centymetry" ? wzrost / 100 :
                jednostkaWzrostu == "Cale" ? wzrost * 0.0254 :
                wzrost * 0.3048;

            double bmi = wagaKg / (wzrostM * wzrostM);
            string kategoria = PobierzKategorieBMI(bmi);
            string sugestia = PobierzSugestie(bmi);

            WynikText.Text = $"BMI: {bmi:F2}";
            KategoriaText.Text = $"Kategoria: {kategoria}";
            SugestiaText.Text = sugestia;

            double? whr = null;
            string typOtylosci = "";
            if (double.TryParse(TaliaInput.Text, out double talia) &&
                double.TryParse(BiodraInput.Text, out double biodra) &&
                biodra > 0)
            {
                whr = talia / biodra;
                typOtylosci = plec == "Mężczyzna"
                    ? (whr > 1.0 ? "otyłość brzuszna" : "brak otyłości")
                    : (whr > 0.85 ? "otyłość brzuszna" : "brak otyłości");
                WHRText.Text = $"WHR: {whr:F2} ({typOtylosci})";
            }
            else
            {
                WHRText.Text = "WHR: brak danych";
            }

            double wzrostCm = wzrostM * 100;
            double bmr = plec == "Mężczyzna"
                ? 10 * wagaKg + 6.25 * wzrostCm - 5 * wiek + 5
                : 10 * wagaKg + 6.25 * wzrostCm - 5 * wiek - 161;
            BMRText.Text = $"BMR: {bmr:F0} kcal/dzień";

            HistoriaPomiarow.Add(new Pomiar
            {
                ID = userId,
                Data = DateTime.Now,
                BMI = Math.Round(bmi, 2),
                Kategoria = kategoria,
                WHR = whr.HasValue ? Math.Round(whr.Value, 2) : (double?)null,
                TypOtylosci = typOtylosci,
                BMR = Math.Round(bmr, 0)
            });
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            BladText.Text = "";


            if (!int.TryParse(UserIDInput.Text, out int userId))
            {
                BladText.Text = "Podaj poprawny ID użytkownika (liczba)";
                return;
            }

            if (HistoriaPomiarow.Count == 0)
            {
                BladText.Text = "Brak wyników do zapisania";
                return;
            }


            string fileName = $"pomiary_{userId}.txt";

            try
            {

                using StreamWriter sw = new StreamWriter(fileName, append: true);

                foreach (var pomiar in HistoriaPomiarow)
                {

                    if (pomiar.ID == userId)
                    {
                        sw.WriteLine($"{pomiar.ID};{pomiar.Data:yyyy-MM-dd HH:mm};{pomiar.BMI:F2};{pomiar.Kategoria};{pomiar.WHR:F2};{pomiar.TypOtylosci};{pomiar.BMR:F0}");
                    }
                }

                BladText.Text = $"Wyniki zapisane do pliku: {fileName}";
            }
            catch (Exception ex)
            {
                BladText.Text = $"Błąd zapisu: {ex.Message}";
            }
        }


        private void EksportujCSV_Click(object sender, RoutedEventArgs e)
        {
            string file = "pomiary.csv";
            StringBuilder sb = new();
            sb.AppendLine("ID;Data;BMI;Kategoria;WHR;TypOtylosci;BMR");

            foreach (var p in HistoriaPomiarow)
            {
                sb.AppendLine($"{p.ID};{p.Data};{p.BMI};{p.Kategoria};{p.WHR};{p.TypOtylosci};{p.BMR}");
            }
            File.WriteAllText(file, sb.ToString(), Encoding.UTF8);
            BladText.Text = "Dane wyeksportowane do pomiary.csv";
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            WagaInput.Text = WzrostInput.Text = WiekInput.Text =
            TaliaInput.Text = BiodraInput.Text = "";
            WynikText.Text = KategoriaText.Text = WHRText.Text = BMRText.Text = SugestiaText.Text = BladText.Text = "";
            JednostkaWagi.SelectedIndex = JednostkaWzrostu.SelectedIndex = PlecCombo.SelectedIndex = -1;
        }

        private string PobierzKategorieBMI(double bmi)
        {
            if (bmi < 18.5) return "Niedowaga";
            else if (bmi < 24.9) return "Prawidłowa masa ciała";
            else if (bmi < 29.9) return "Nadwaga";
            else return "Otyłość";
        }

        private string PobierzSugestie(double bmi)
        {
            if (bmi < 18.5) return "Zwiększ kaloryczność i skonsultuj się z dietetykiem";
            else if (bmi < 24.9) return "Utrzymuj zdrowy styl życia";
            else if (bmi < 29.9) return "Zwiększ aktywność fizyczną";
            else return "Skonsultuj się z lekarzem i zmień dietę";
        }
    }

    public class Pomiar
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public double BMI { get; set; }
        public string Kategoria { get; set; }
        public double? WHR { get; set; }
        public string TypOtylosci { get; set; }
        public double BMR { get; set; }
    }
}