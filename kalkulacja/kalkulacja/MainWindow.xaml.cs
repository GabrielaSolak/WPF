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

namespace kalkulacja
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
        /*
            benzyna - 0  5zł
            olej - 1  6zł
            gaz - 2  7zł
         */
        int rodzaj_paliwa = -1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rodzaj_paliwa = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rodzaj_paliwa = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rodzaj_paliwa = 2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string dystansText = dystans.Text;
            if (double.TryParse(dystansText, out double dystansKm)) ;

            string spalanieText = spalanie.Text;
            if (double.TryParse(spalanieText, out double spalanieKm)) ;

            if(rodzaj_paliwa == 0)
            {
                double koszt = dystansKm * spalanieKm * 5;
                wynik.Text = $"{koszt}";
            }
            if (rodzaj_paliwa == 1)
            {
                double koszt = dystansKm * spalanieKm * 6;
                wynik.Text = $"{koszt}";
            }
            if (rodzaj_paliwa == 2)
            {
                double koszt = dystansKm * spalanieKm * 7;
                wynik.Text = $"{koszt}";
            }

        }
    }
}