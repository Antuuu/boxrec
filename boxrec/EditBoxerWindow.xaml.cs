﻿using System;
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
        public EditBoxerWindow()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        { 
            using (BoxrecContext db = new BoxrecContext(MainWindow.connectionString))
            {
                int idToEdit = Int32.Parse(txtID.Text);
                Boxer boxerToEdit = db.Boxers
                    .Where(x => x.ID == idToEdit)
                    .First();
                boxerToEdit.Name = txtName.Text;
                boxerToEdit.Surname = txtSurname.Text;
                boxerToEdit.Division_ID = Int32.Parse(txtDivision.Text);
                boxerToEdit.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);
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