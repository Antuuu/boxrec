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
        public static string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";

        // TODO
        // tabele w SQL? - walki, dywizje
        // obsługa inputów w add & edit
        // dodanie obsługi zdarzeń save w add&edit dla optymalizacji? 
        // okienko show details, w tym datagrid z walkami, dodawanie/edycja walk, wyswietlanie tytułów


        public MainWindow()
        {
            InitializeComponent();
            Boxers_DataGrid.ItemsSource = FetchBoxers();
        }


        public static List<Boxer> FetchBoxers()
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                List<Boxer> boxers = new List<Boxer>();
                return boxers = db.Boxers.ToList();
            }
        }


        private void ChangeText(object sender, RoutedEventArgs e)
        {
            //int id = (int)((Button)sender).CommandParameter;
            //using (BoxrecContext db = new BoxrecContext(connectionString))
            //{
            //    Boxer boxer = db.Boxers.First(c => c.ID == id);
            //    InitializeComponent();
            //    Boxer_Details p = new Boxer_Details();
            //    p.Show();
            //    p.DataContext = boxer;
            //}

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SecondName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            AddBoxer addBoxer = new AddBoxer();
            addBoxer.ShowDialog();
            Boxers_DataGrid.ItemsSource = FetchBoxers();
        }

        private void Remove_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                if (Boxers_DataGrid.SelectedItem != null)
                {

                    Boxer boxerToRemove = (Boxer)Boxers_DataGrid.SelectedItem;
                    db.Boxers.Remove(boxerToRemove);
                    db.SaveChanges();
                }
                Boxers_DataGrid.ItemsSource = FetchBoxers();
            }
        }
        

        private void Edit_Boxer_Button_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                if (Boxers_DataGrid.SelectedItem != null)
                {

                    Boxer boxerToEdit = (Boxer)Boxers_DataGrid.SelectedItem;
                    EditBoxer editBoxer = new EditBoxer();

                    editBoxer.DataContext = boxerToEdit;

                    editBoxer.ID_TextBox.Text = boxerToEdit.ID.ToString();
                    editBoxer.Name_TextBox.Text = boxerToEdit.Name;
                    editBoxer.Surname_TextBox.Text = boxerToEdit.Surname;
                    editBoxer.Division_TextBox.Text = boxerToEdit.Division.ToString();
                    editBoxer.DateOfBirth_TextBox.Text = boxerToEdit.DateOfBirth.ToString();

                    editBoxer.ShowDialog();
                }
            }
            Boxers_DataGrid.ItemsSource = FetchBoxers();

        }


        private void Boxers_DataGrid_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }


        private void Show_Details_Click(object sender, RoutedEventArgs e)
        {
            Boxer boxerToEdit = (Boxer)Boxers_DataGrid.SelectedItem;
            BoxerDetails boxerDetails = new BoxerDetails();

            boxerDetails.DataContext = boxerToEdit;
            
            boxerDetails.ID_TextBox.Text = boxerToEdit.ID.ToString();
            boxerDetails.Name_TextBox.Text = boxerToEdit.Name;
            boxerDetails.Surname_TextBox.Text = boxerToEdit.Surname;
            boxerDetails.Division_TextBox.Text = boxerToEdit.Division.ToString();
            boxerDetails.DateOfBirth_TextBox.Text = boxerToEdit.DateOfBirth.ToString();


            boxerDetails.ShowDialog();
        }

    }
}
