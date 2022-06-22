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
    /// Interaction logic for EditBoxer.xaml
    /// </summary>
    public partial class EditBoxer : Window
    {
        public EditBoxer()
        {
            InitializeComponent();
        }

        public delegate void DataSavedEventHandler(object sender, EventArgs e);


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        { 
            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {
                int idToEdit = Int32.Parse(ID_TextBox.Text);
                Boxer boxerToEdit = db.Boxers
                    .Where(x => x.ID == idToEdit)
                    .First();
                boxerToEdit.Name = Name_TextBox.Text;
                boxerToEdit.Surname = Surname_TextBox.Text;
                boxerToEdit.Division = Int32.Parse(Division_TextBox.Text);
                boxerToEdit.DateOfBirth = DateTime.Parse(DateOfBirth_TextBox.Text);
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
