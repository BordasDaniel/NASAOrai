using NASACLI;
using System.Collections.ObjectModel;
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

namespace NASAWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<Kuldetes> kuldetesek;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMinden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Program.Beolvas();
                kuldetesek = new ObservableCollection<Kuldetes>(Program.kuldetesek);
                dgKuldetesek.ItemsSource = kuldetesek;
                MessageBox.Show("Sikeres beolvasás!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sikertelen beolvasás: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgKuldetesek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgKuldetesek.SelectedItem is Kuldetes k)
            {
                lblKiv.Content = k.Nev;
                pgbTeher.Value = k.HasznosTeher;
            }
        }

        private void btnStat_Click(object sender, RoutedEventArgs e)
        {
            int emberesKuldetesekSzama = kuldetesek.Count(k => k.Legenyseg > 0);
            int emberNelkululiKuldetesekSzama = kuldetesek.Count(k => k.Legenyseg == 0);
            double koltsegAtlag = kuldetesek.Average(k => k.Koltseg);
            double hasznosTeherAtlag = kuldetesek.Average(k => k.HasznosTeher);
            MessageBox.Show($"Emberrel: {emberesKuldetesekSzama}\nEmber nélkül: {emberNelkululiKuldetesekSzama}\nKöltség átlag: {koltsegAtlag:N2}\nHasznos teher átlag: {hasznosTeherAtlag:N2}", "Statisztika", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}