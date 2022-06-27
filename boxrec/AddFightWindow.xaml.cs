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
        public AddFightWindow()
        {
            InitializeComponent();
        }
        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
