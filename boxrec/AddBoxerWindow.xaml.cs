using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        DateTime? start = DateTime.Today.AddDays(1);

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BoxrecContext db = new BoxrecContext())
                {
                    Boxer boxerToAdd = new Boxer
                    {
                        Name = tbxName.Text,
                        Surname = tbxSurname.Text,
                        Division_ID = cmbDivision.SelectedIndex + 1,
                        DateOfBirth = dpDateOfBirth.SelectedDate,
                        Photo_Url = tbxPhotoURL.Text,
                    };

                    db.Boxers.Add(boxerToAdd);
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
            // more error handling would be needed here - this is asking for trouble!
            String s = (String)e.DataObject.GetData(typeof(String));
            if (!TextAllowed(s)) e.CancelCommand();
        }
    }
}


