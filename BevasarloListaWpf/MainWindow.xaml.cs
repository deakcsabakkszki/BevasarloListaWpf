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

namespace BevasarloListaWpf
{
    public class ItemModel
    {
        public String Nev {  get; set; }
        public int Mennyiség {  get; set; }
        public int Ár {  get; set; }
        public String Kategória {  get; set; }

        public int Összesen {  get; set; }
        public ItemModel(string nev, int mennyiség, int ár, string kategória)
        {
            Nev = nev;
            Mennyiség = mennyiség;
            Ár = ár;
            Kategória = kategória;
            Összesen = Mennyiség * Ár;
        }
    }
    public partial class MainWindow : Window
    {
        List<ItemModel> termekek=new List<ItemModel>();
        public MainWindow()
        {
            InitializeComponent();
            termekek.Add(new ItemModel("Tej", 5, 450, "A"));
            termekek.Add(new ItemModel("Kenyer", 10, 350, "B"));
            termekek.Add(new ItemModel("Sajt", 2, 1200, "A"));
            termekek.Add(new ItemModel("Alma", 20, 200, "C"));
            termekek.Add(new ItemModel("Narancs", 15, 300, "C"));
            termekek.Add(new ItemModel("Hús", 3, 2500, "D"));
            termekek.Add(new ItemModel("Csokoládé", 7, 900, "B"));
            termekek.Add(new ItemModel("Kenyér", 1, 450, "B"));
            termekek.Add(new ItemModel("Tej", 12, 400, "A"));
            termekek.Add(new ItemModel("Sajt", 5, 1500, "D"));
            dataGrid.ItemsSource = termekek;
        }

        private void hozza_adas(object sender, RoutedEventArgs e)
        {
            var ujtermek=new Hozzaadas();

            if (ujtermek.ShowDialog()==true)
            {
                termekek.Add(ujtermek.ujtermek);
                dataGrid.ItemsSource = termekek;
                dataGrid.Items.Refresh();
            }

        }

        private void torles(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem!=null)
            {
                termekek.Remove((ItemModel)dataGrid.SelectedItem);
                dataGrid.ItemsSource = termekek;
                dataGrid.Items.Refresh();
            }
        }

        private void aTipus3Draga(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(t => t.Kategória == "A").OrderByDescending(x=>x.Összesen).Take(3);
        }

        private void Top5Osszerint(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.OrderByDescending(t => t.Összesen).Take(5);
        }
    }
}