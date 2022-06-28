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
    public partial class AddFightWindow : Window
    {
        public Boxer boxer1;
        public Boxer boxer2;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public void UpdateBoxer1()
        {
            tbxID1.Text = boxer1.ID.ToString();
            tbxName1.Text = boxer1.Name;
            tbxSurname1.Text = boxer1.Surname;
            tbxDivision1.Text = boxer1.Division;
            tbxDateOfBirth1.Text = boxer1.DateOfBirth.ToString();
        }

        public void UpdateBoxer2()
        {
            tbxID2.Text = boxer2.ID.ToString();
            tbxName2.Text = boxer2.Name;
            tbxSurname2.Text = boxer2.Surname;
            tbxDivision2.Text = boxer2.Division;
            tbxDateOfBirth2.Text = boxer2.DateOfBirth.ToString();
        }

        public AddFightWindow()
        {
            InitializeComponent();
        }
        

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {

            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {

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

                Fight fightToAdd = new Fight
                {
                    Boxer1_ID = boxer1.ID,
                    Boxer2_ID = boxer2.ID,
                    Winner_ID = winnerID,
                    DateOfFight = dpDateOfFight.SelectedDate,
                };

                db.Fights.Add(fightToAdd);
                await db.SaveChangesAsync();
            }

            Close();
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
