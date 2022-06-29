using Microsoft.Data.SqlClient;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", tbxUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", pbxPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxUsername.Focus();
        }

        private void tbxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxUsername.Text) && tbxUsername.Text.Length > 0)
            {
                txtUsername.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtUsername.Visibility = Visibility.Visible;
            }
        }

        private void txtPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pbxPassword.Focus();
        }

        private void pbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(pbxPassword.Password) && pbxPassword.Password.Length > 0)
            {
                txtPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPassword.Visibility = Visibility.Visible;
            }
        }

    }
}
