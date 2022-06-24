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
            dgridBoxers.ItemsSource = FetchBoxers();
        }


        public static List<Boxer> FetchBoxers()
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                List<Boxer> boxers = new List<Boxer>();
                return boxers = db.Boxers.ToList();
            }
        }

        private void btnAddBoxer_Click(object sender, RoutedEventArgs e)
        {
            AddBoxerWindow addBoxer = new AddBoxerWindow();
            addBoxer.ShowDialog();
            dgridBoxers.ItemsSource = FetchBoxers();
        }

        private void btnRemoveBoxer_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                if (dgridBoxers.SelectedItem != null)
                {

                    Boxer boxerToRemove = (Boxer)dgridBoxers.SelectedItem;
                    db.Boxers.Remove(boxerToRemove);
                    db.SaveChanges();
                }
                dgridBoxers.ItemsSource = FetchBoxers();
            }
        }
        

        private void btnEditBoxer_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                if (dgridBoxers.SelectedItem != null)
                {

                    Boxer boxerToEdit = (Boxer)dgridBoxers.SelectedItem;
                    EditBoxerWindow editBoxer = new EditBoxerWindow();

                    editBoxer.DataContext = boxerToEdit;

                    editBoxer.tbxID.Text = boxerToEdit.ID.ToString();
                    editBoxer.tbxName.Text = boxerToEdit.Name;
                    editBoxer.tbxSurname.Text = boxerToEdit.Surname;
                    editBoxer.tbxDivision.Text = boxerToEdit.Division_ID.ToString();
                    editBoxer.tbxDateOfBirth.Text = boxerToEdit.DateOfBirth.ToString();

                    editBoxer.ShowDialog();
                }
            }

            dgridBoxers.ItemsSource = FetchBoxers();
        }


        private void miViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (dgridBoxers.SelectedItem != null)
            {
                Boxer boxerToEdit = (Boxer)dgridBoxers.SelectedItem;
                BoxerDetailsWindow boxerDetails = new BoxerDetailsWindow();

                boxerDetails.DataContext = boxerToEdit;

                boxerDetails.tbxID.Text = boxerToEdit.ID.ToString();
                boxerDetails.tbxName.Text = boxerToEdit.Name;
                boxerDetails.tbxSurname.Text = boxerToEdit.Surname;
                boxerDetails.tbxDivision.Text = boxerToEdit.Division_ID.ToString();
                boxerDetails.tbxDateOfBirth.Text = boxerToEdit.DateOfBirth.ToString("dd-MM-yyyy");

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(boxerToEdit.Photo_Url.ToString());
                bitmapImage.EndInit();
                boxerDetails.imgBoxerPhoto.Source = bitmapImage;

                boxerDetails.ShowDialog();
            }
            
        }


        private void btnFightsEditor_Click(object sender, RoutedEventArgs e)
        {
            FightsEditorWindow fightsEditor = new FightsEditorWindow();

            fightsEditor.ShowDialog();

        }

    }
}
