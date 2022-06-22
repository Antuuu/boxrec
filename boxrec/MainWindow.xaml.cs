using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace boxrec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string[] currentView = new string[] { "Boxers", "Clubs" };
            InitializeComponent();
            data_grid.ItemsSource = FetchBoxers();
            
        }

        // TODO
        // okienko dodawania boxerów
        // 

        public static List<Boxer> FetchBoxers()
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                List<Boxer> boxers = new List<Boxer>();
                return boxers = db.Boxers.ToList();
            }
        }


        private void ChangeText(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                Boxer boxer = db.Boxers.First(c => c.ID == id);
                InitializeComponent();
                Boxer_Details p = new Boxer_Details();
                p.Show();
                p.DataContext = boxer;
            }

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SecondName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
            //using (BoxrecContext db = new BoxrecContext(connectionString))
            //{
            //    db.Boxers.Add(new Boxer { dateofbirth = DateTime.Parse(dateofbirth.Text), name = name.Text , division = int.Parse(kategoriawagowa.Text),  surname = surname.Text});
            //    db.SaveChanges();
            //    data_grid.ItemsSource = FetchBoxers();
            //}
        }

        private void Remove_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
            //using (BoxrecContext db = new BoxrecContext(connectionString))
            //{
            //    int idToRemove = int.Parse(ID.Text);
            //    Boxer BoxerToDelete = db.Boxers.First(c => c.ID == idToRemove);
            //    db.Boxers.Remove(BoxerToDelete);
            //    db.SaveChanges();
            //    data_grid.ItemsSource = FetchBoxers();
            //}
        }

        private void Edit_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dateofbirth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kategoriawagowa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
