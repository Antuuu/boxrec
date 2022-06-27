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

        }

        private void btnRemoveFight_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
