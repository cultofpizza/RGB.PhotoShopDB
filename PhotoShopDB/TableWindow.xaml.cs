using System;
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
using System.Reflection;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Windows.Shapes;
using static PhotoShopDB.Entities;

namespace PhotoShopDB
{
    /// <summary>
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        Entities abc;
        public TableWindow()
        {
            InitializeComponent();

            abc = new Entities();
            var listOfTables = typeof(Entities)
                .GetProperties()
                .Where(p => p.PropertyType.Name == "DbSet`1")
                .ToList();
            DbSet<Client> table = abc.Client;
            Clients.ItemsSource = table.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NewClient newClient = new NewClient();
            newClient.ShowDialog();
            Update_Click(this, e);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewClient newClient = new NewClient((Client)Clients.SelectedItem);
                newClient.ShowDialog();

                Update_Click(this, e);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Please select any row and try again.", "Nothing to edit", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItems.Count == 0) return;
            var result = MessageBox.Show("Are you sure you want to delete " + Clients.SelectedItems.Count + " rows", "Delete selected rows", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Clients.SelectedItems is var client)
            {

                if (result == MessageBoxResult.Yes)
                {
                    foreach (Client item in client)
                    {
                        abc.Client.Remove(item);
                    }
                    abc.SaveChanges();
                    Update_Click(this, e);
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            abc = new Entities();
            Clients.ItemsSource = abc.Client.ToList();
        }

        private void TableSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
