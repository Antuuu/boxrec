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
    /// Interaction logic for AddBoxer.xaml
    /// </summary>
    public partial class AddBoxerWindow : Window
    {
        public AddBoxerWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {
                Boxer boxerToAdd = new Boxer 
                { 
                    Name = tbxName.Text, 
                    Surname = tbxSurname.Text, 
                    Division_ID = Int32.Parse(tbxDivision.Text), 
                    DateOfBirth = DateTime.Parse(tbxDateOfBirth.Text) 
                };

                    db.Boxers.Add(boxerToAdd);
                    db.SaveChanges();
            }

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
