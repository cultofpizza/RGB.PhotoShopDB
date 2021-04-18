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
using static PhotoShopDB.Entities;

namespace PhotoShopDB
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        bool editMode;
        int id;
        Entities abc = new Entities();
        public NewClient()
        {
            InitializeComponent();
            editMode = false;
        }

        public NewClient(Client client)
        {
            InitializeComponent();
            lName.Text = client.Lname;
            fName.Text = client.Fname;
            mName.Text = client.Mname;
            phone.Text = client.Phone_number;
            email.Text = client.Email;
            id = client.Id_client;
            editMode = true;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!(lName.Text == "" || fName.Text == "" || (phone.Text == "" || email.Text == "")))
            {
                Client client = new Client
                {
                    Lname = lName.Text,
                    Fname = fName.Text,
                    Mname = mName.Text,
                    Phone_number = phone.Text,
                    Email = email.Text
                };
                if (editMode)
                {
                    var a = abc.Client.Where(i => i.Id_client == id).FirstOrDefault();
                    a.Lname = lName.Text;
                    a.Fname = fName.Text;
                    a.Mname = mName.Text;
                    a.Phone_number = phone.Text;
                    a.Email = email.Text;
                }
                else
                {
                    abc.Client.Add(client);
                }
                abc.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Field(s) can't be empty!", "Not enough data", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
