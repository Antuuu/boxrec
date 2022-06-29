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
    /// Interaction logic for AddFightWindow.xaml
    /// </summary>
    public partial class EditFightWindow : Window
    {
        public Boxer boxer1;
        public Boxer boxer2;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        /// <summary>
        /// Method <c>UpdateBoxer1()</c> mapping textbox of UpdateBoxer window to data of first Boxer who participated in fight
        /// </summary>
        public void UpdateBoxer1()
        {
            tbxID1.Text = boxer1.ID.ToString();
            tbxName1.Text = boxer1.Name;
            tbxSurname1.Text = boxer1.Surname;
            tbxDivision1.Text = boxer1.Division;
            tbxDateOfBirth1.Text = boxer1.DateOfBirth.ToString();
        }
        /// <summary>
        /// Method <c>UpdateBoxer2()</c> mapping textbox of UpdateBoxer window to data of second Boxer who participated in fight
        /// </summary>
        public void UpdateBoxer2()
        {
            tbxID2.Text = boxer2.ID.ToString();
            tbxName2.Text = boxer2.Name;
            tbxSurname2.Text = boxer2.Surname;
            tbxDivision2.Text = boxer2.Division;
            tbxDateOfBirth2.Text = boxer2.DateOfBirth.ToString();
        }

        /// <summary>
        /// Initalize and display EdidFighWindow
        /// </summary>/// 
        public EditFightWindow()
        {
            InitializeComponent();
        }
        

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
                {
                    int idToEdit = Int32.Parse(tbxFightID.Text);

                    Fight fight = db.Fights
                                  .Where(f => f.ID == idToEdit)
                                  .First();

                    int winnerID;

                    if (rbtnBoxer1.IsChecked == true)
                    {
                        winnerID = boxer1.ID;
                    }
                    else if (rbtnBoxer2.IsChecked == true)
                    {
                        winnerID = boxer2.ID;
                    }
                    else winnerID = 0;

                    fight.Boxer1_ID = boxer1.ID;
                    fight.Boxer2_ID = boxer2.ID;
                    fight.Winner_ID = winnerID;
                    fight.DateOfFight = dpDateOfFight.SelectedDate;



                    await db.SaveChangesAsync();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid or empty date.");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSelectBoxer1_Click(object sender, RoutedEventArgs e)
        {
            SelectBoxer1Window selectBoxer1 = new SelectBoxer1Window();
            selectBoxer1.ShowDialog();
        }

        private void btnSelectBoxer2_Click(object sender, RoutedEventArgs e)
        {
            SelectBoxer2Window selectBoxer2 = new SelectBoxer2Window();
            selectBoxer2.ShowDialog();
        }
    }
}
