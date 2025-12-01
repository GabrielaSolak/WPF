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

namespace egzamin_poczta
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

        private void SprawdzCene_Click(object sender, RoutedEventArgs e)
        {
            string wybor = "";

            if (rbList.IsChecked == true) {
                wybor = "list";
                //Image_zdj.Source = "/pocztowka.png";
                Image_zdj.Source = new BitmapImage(new Uri("pack://application:,,,/list.png"));

            }
            else if (rbPaczka.IsChecked == true) {
                wybor = "paczka";
                Image_zdj.Source = new BitmapImage(new Uri("pack://application:,,,/paczka.png"));

            }
            else if (rbPocztowka.IsChecked == true) {
                wybor = "pocztowka";
                Image_zdj.Source = new BitmapImage(new Uri("pack://application:,,,/pocztowka.png"));

            }
        }
    }
}