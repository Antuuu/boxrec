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
    public partial class EditBoxerWindow : Window
    {
        /// <summary>
        /// Initalize and display EditBoxerWindow
        /// </summary>
        public EditBoxerWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BoxrecContext db = new BoxrecContext())
                {
                    int idToEdit = Int32.Parse(tbxID.Text);
                    Boxer boxerToEdit = db.Boxers
                        .Where(x => x.ID == idToEdit)
                        .First();
                    boxerToEdit.Name = tbxName.Text;
                    boxerToEdit.Surname = tbxSurname.Text;
                    boxerToEdit.Division_ID = cmbDivision.SelectedIndex + 1;
                    boxerToEdit.DateOfBirth = dpDateOfBirth.SelectedDate;
                    boxerToEdit.Photo_Url = tbxPhotoURL.Text;
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

        private Boolean TextAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLetter(c) || Char.IsControl(c)) continue;
                else return false;
            }
            return true;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            String s = (String)e.DataObject.GetData(typeof(String));
            if (!TextAllowed(s)) e.CancelCommand();
        }

    }
}
