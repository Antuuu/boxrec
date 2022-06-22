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
    public partial class AddBoxer : Window
    {
        public AddBoxer()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {
                Boxer boxerToAdd = new Boxer 
                { 
                    Name = Name_TextBox.Text, 
                    Surname = Surname_TextBox.Text, 
                    Division = Int32.Parse(Division_TextBox.Text), 
                    DateOfBirth = DateTime.Parse(DateOfBirth_TextBox.Text) 
                };

                    db.Boxers.Add(boxerToAdd);
                    db.SaveChanges();
            }

            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
