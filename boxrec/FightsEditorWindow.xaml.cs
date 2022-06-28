using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace boxrec
{
    /// <summary>
    /// Interaction logic for FightsEditorWindow.xaml
    /// </summary>
    public partial class FightsEditorWindow : Window
    {
        public FightsEditorWindow()
        {
            InitializeComponent();
            dgridFights.ItemsSource = FetchFights();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public static List<Fight> FetchFights()
        {
            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {
                List<Fight> fights = new List<Fight>();
                return fights = db.Fights.ToList();
            }
        }

        private void btnAddFight_Click(object sender, RoutedEventArgs e)
        {
            AddFightWindow addFight = new AddFightWindow();
            addFight.ShowDialog();
            dgridFights.ItemsSource = FetchFights();
        }

        private void btnEditFight_Click(object sender, RoutedEventArgs e)
        {
            if (dgridFights.SelectedItem != null)
            {
                using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
                {
                    EditFightWindow editFight = new EditFightWindow();
                    Fight fightToEdit = (Fight)dgridFights.SelectedItem;

                    editFight.boxer1 = (from b in db.Boxers where b.ID == fightToEdit.Boxer1_ID select b).FirstOrDefault();
                    editFight.boxer2 = (from b in db.Boxers where b.ID == fightToEdit.Boxer2_ID select b).FirstOrDefault();

                    editFight.tbxFightID.Text = fightToEdit.ID.ToString();

                    editFight.tbxID1.Text = fightToEdit.Boxer1_ID.ToString();
                    editFight.tbxID2.Text = fightToEdit.Boxer2_ID.ToString();

                    editFight.tbxName1.Text = editFight.boxer1.Name;
                    editFight.tbxName2.Text = editFight.boxer2.Name;

                    editFight.tbxSurname1.Text = editFight.boxer1.Surname;
                    editFight.tbxSurname2.Text = editFight.boxer2.Surname;

                    editFight.tbxDivision1.Text = editFight.boxer1.Division;
                    editFight.tbxDivision2.Text = editFight.boxer2.Division;

                    editFight.tbxDateOfBirth1.Text = editFight.boxer1.DateOfBirth.ToString();
                    editFight.tbxDateOfBirth2.Text = editFight.boxer2.DateOfBirth.ToString();

                    editFight.dpDateOfFight.SelectedDate = fightToEdit.DateOfFight;

                    if (fightToEdit.Winner_ID == fightToEdit.Boxer1_ID)
                    {
                        editFight.rbtnBoxer1.IsChecked = true;
                    } 
                    else if (fightToEdit.Winner_ID == fightToEdit.Boxer2_ID)
                    {
                        editFight.rbtnBoxer2.IsChecked = true;
                    }
                    else if (fightToEdit.Winner_ID == 0)
                    {
                        editFight.rbtnDraw.IsChecked = true;
                    }

                        editFight.ShowDialog();

                    dgridFights.ItemsSource = FetchFights();

                }
            }
        }

        private void btnRemoveFight_Click(object sender, RoutedEventArgs e)
        {
            if (dgridFights.SelectedItem != null)
            {
                using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
                {
                    Fight fightToRemove = (Fight)dgridFights.SelectedItem;
                    db.Remove(fightToRemove);
                    db.SaveChanges();
                    dgridFights.ItemsSource = FetchFights();
                }
            }
        }
    }
}
