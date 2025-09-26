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

namespace kalkulator
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
        string wybrana_liczba = "";

        private void Click_1(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "1";
            wynik.Text = wybrana_liczba;
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "2";
            wynik.Text = wybrana_liczba;
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "3";
            wynik.Text = wybrana_liczba;
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "4";
            wynik.Text = wybrana_liczba;
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "5";
            wynik.Text = wybrana_liczba;
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "6";
            wynik.Text = wybrana_liczba;
        }

        private void Click_7(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "7";
            wynik.Text = wybrana_liczba;
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "8";
            wynik.Text = wybrana_liczba;
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "9";
            wynik.Text = wybrana_liczba;
        }

        private void Click_0(object sender, RoutedEventArgs e)
        {
            wybrana_liczba += "0";
            wynik.Text = wybrana_liczba;
        }

        private void pokazWynik(object sender, RoutedEventArgs e)
        {
            //wynik.Text = wybrana_liczba;
        }

        private void wyczysc(object sender, RoutedEventArgs e)
        {
            wybrana_liczba = "";
            wynik.Text = wybrana_liczba;
        }
    }
}