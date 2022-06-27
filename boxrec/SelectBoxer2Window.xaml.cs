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
    /// Interaction logic for SelectBoxer1Window.xaml
    /// </summary>
    public partial class SelectBoxer2Window : Window
    {
        public SelectBoxer2Window()
        {
            InitializeComponent();
            dgridBoxer2.ItemsSource = MainWindow.FetchBoxers();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgridBoxer2.SelectedItem != null)
            {
                Boxer selected = (Boxer)dgridBoxer2.SelectedItem;
                if (Application.Current.Windows.OfType<AddFightWindow>().Any())
                {
                    foreach (AddFightWindow window in Application.Current.Windows.OfType<AddFightWindow>())
                    {
                        int otherID = 0;
                        if (!String.IsNullOrEmpty(window.tbxID1.Text))
                            otherID = Int32.Parse(window.tbxID1.Text);

                        if (selected.ID != otherID)
                        {
                            window.boxer2 = (Boxer)dgridBoxer2.SelectedItem;
                            window.UpdateBoxer2();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("You must select two different boxers!");
                        }
                    }
                }
                else if (Application.Current.Windows.OfType<EditFightWindow>().Any())
                {
                    foreach (EditFightWindow window in Application.Current.Windows.OfType<EditFightWindow>())
                    {
                        int otherID = 0;
                        if (!String.IsNullOrEmpty(window.tbxID1.Text))
                            otherID = Int32.Parse(window.tbxID1.Text);

                        if (selected.ID != otherID)
                        {
                            window.boxer2 = (Boxer)dgridBoxer2.SelectedItem;
                            window.UpdateBoxer2();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("You must select two different boxers!");
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
