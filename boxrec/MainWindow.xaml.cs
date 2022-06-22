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

        }

        private void Edit_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                Boxer b = (Boxer)data_grid.SelectedItem;
                EditBoxer editBoxer = new EditBoxer();
                editBoxer.DataContext = b;
                editBoxer.ID_TextBox.Text = b.ID.ToString();
                editBoxer.Name_TextBox.Text = b.name.ToString();
                editBoxer.Surname_TextBox.Text = b.surname.ToString();
                editBoxer.Division_TextBox.Text = b.division.ToString();
                editBoxer.Date_of_birth_TextBox.Text = b.dateofbirth.ToString();

                editBoxer.ShowDialog();

            }

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
