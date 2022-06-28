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
    
    //TO DO list
    //Db:
    //1.) Klucze obce na bazie(boxers + divisions)
    //2.) uzupełnienie bazy
    //Dokumentacja:
    //1.) Dokumentacja xml publicznych składników kodu.
    //2.) Readme.md
    //Kod:
    //1.) Zakres dat w datepickerach
    //2.) Zmiana możliwych metod class etc na private
    //3.) Sprawdzenie properties class
    //4.) Zabezpiecznie operacji bazodanowych - np.usunięcie Boxera mającego walki
    //5.) Unit tests
    //6.) Instalator

    public partial class MainWindow : Window
    {
        public static string connectionString = @"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True";

        /// <summary>
        /// Initalize components and use method FetchBoxers()
        /// </summary>
        /// 
        public MainWindow()
        {
            InitializeComponent();
            dgridBoxers.ItemsSource = FetchBoxers();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Method <c>FetchBoxers</c>, fetching list of all Boxers from database and returning List<Boxer>
        /// </summary>
        /// 
        public static List<Boxer> FetchBoxers()
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                List<Boxer> boxers = new List<Boxer>();
                return boxers = db.Boxers.ToList();
            }
        }

        private static List<Fight> FetchFights(Boxer boxer)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                List<Fight> fights = new List<Fight>();
                fights = (from f in db.Fights where f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID select f).ToList();
                var wins = (from f in db.Fights where f.Winner_ID == boxer.ID select f).ToList();
                var losses = (from f in db.Fights where (f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID) && (f.Winner_ID != boxer.ID && f.Winner_ID != null) select f).ToList();
                var draws = (from f in db.Fights where (f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID) && f.Winner_ID == null select f).ToList();
                foreach (Fight fight in wins)
                {
                    fight.FightResult = "Win";
                }
                boxer.Wins = wins.Count;

                foreach (Fight fight in losses)
                {
                    fight.FightResult = "Loss";
                }
                boxer.Loses = losses.Count;

                foreach (Fight fight in draws)
                {
                    fight.FightResult = "Draw";
                }
                boxer.Draws = draws.Count;

                for (int i = 0; i < fights.Count; i++)
                {
                    fights[i].FightNumber = i + 1;
                    if (fights[i].Boxer1_ID == boxer.ID){
                        fights[i].Opponent = (from b in db.Boxers where b.ID == fights[i].Boxer2_ID select b.Name + " " + b.Surname).First().ToString();
                    }
                    else
                    {
                        fights[i].Opponent = fights[i].Boxer1_ID.ToString();
                        fights[i].Opponent = (from b in db.Boxers where b.ID == fights[i].Boxer1_ID select b.Name + " " + b.Surname).First().ToString();

                    }
                }
                return fights;
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnAddBoxer_Click(object sender, RoutedEventArgs e)
        {
            AddBoxerWindow addBoxer = new AddBoxerWindow();
            addBoxer.ShowDialog();
            dgridBoxers.ItemsSource = FetchBoxers();
        }

        private async void btnRemoveBoxer_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(connectionString))
            {
                if (dgridBoxers.SelectedItem != null)
                {

                    Boxer boxerToRemove = (Boxer)dgridBoxers.SelectedItem;
                    db.Boxers.Remove(boxerToRemove);
                    await db.SaveChangesAsync();
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

                    editBoxer.tbxID.Text = boxerToEdit.ID.ToString();
                    editBoxer.tbxName.Text = boxerToEdit.Name;
                    editBoxer.tbxSurname.Text = boxerToEdit.Surname;
                    editBoxer.cmbDivision.SelectedIndex = boxerToEdit.Division_ID - 1;
                    editBoxer.dpDateOfBirth.SelectedDate = boxerToEdit.DateOfBirth;
                    editBoxer.tbxPhotoURL.Text = boxerToEdit.Photo_Url;

                    editBoxer.ShowDialog();
                }
            }
            dgridBoxers.ItemsSource = FetchBoxers();
        }


        private void miViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (dgridBoxers.SelectedItem != null)
            {
                Boxer boxerToShow = (Boxer)dgridBoxers.SelectedItem;
                BoxerDetailsWindow boxerDetails = new BoxerDetailsWindow();


                boxerDetails.DataContext = boxerToShow;

                boxerDetails.tbxID.Text = boxerToShow.ID.ToString();
                boxerDetails.txtFullName.Text = $"{boxerToShow.Name} {boxerToShow.Surname}";
                boxerDetails.tbxDivision.Text = boxerToShow.Division;
                boxerDetails.tbxDateOfBirth.Text = boxerToShow.DateOfBirth?.ToString("dd-MM-yyyy") ?? "N/A";

                var bitmapImage = new BitmapImage();
                try
                {
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(boxerToShow.Photo_Url.ToString());
                    bitmapImage.EndInit();
                    boxerDetails.imgBoxerPhoto.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    if (string.IsNullOrEmpty(boxerToShow.Photo_Url))
                    {
                        boxerDetails.txtNoPhotoURL.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        boxerDetails.txtInvalidPhotoURL.Visibility = Visibility.Visible;
                    }
                }


                var fights = FetchFights(boxerToShow);
                boxerDetails.dgridBoxerFights.ItemsSource = fights;

                // generate and setup record of boxer
                boxerDetails.tbxWins.Text = boxerToShow.Wins.ToString();
                boxerDetails.tbxDraws.Text = boxerToShow.Draws.ToString();
                boxerDetails.tbxLosses.Text = boxerToShow.Loses.ToString();





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
