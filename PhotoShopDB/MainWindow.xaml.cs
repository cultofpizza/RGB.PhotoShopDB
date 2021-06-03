using Microsoft.Toolkit.Uwp.Notifications;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PhotoShopDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (Verify())
            {
                Hide();
                TableWindow tw = new TableWindow();
                CaptchaWindow cw = new CaptchaWindow(tw.ShowDialog);
                cw.ShowDialog();

                Show();
            }
            else
            {
                MessageBox.Show("Неверный логин и/или пароль\nПроверьте правильность введенных данных", "Ошибка входа", MessageBoxButton.OK);
            }
        }

        bool Verify()
        {
            Entities abc = new Entities();
            var login = abc.Employee.Where(i => i.login == Login.Text && i.password == Password.Password).ToList();

            return login.Count > 0;
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogIn(sender, e);
            }
        }

        private void btnLoginAsCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
