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

namespace PhotoShopDB
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        bool actionMode;
        Action openAction;
        Func<bool?> openFunc;
        BitmapCaptcha captcha = new BitmapCaptcha(5);
        public CaptchaWindow(Action action)
        {
            InitializeComponent();
            actionMode = true;
            openAction = action;
            captcha.Generate();
            CaptchaText.Text = captcha.CaptchaText;
            bitmapCaptcha.Source = captcha.CaptchaImage;
        }
        public CaptchaWindow(Func<bool?> func)
        {
            InitializeComponent();
            actionMode = false;
            openFunc = func;
            captcha.Generate();
            CaptchaText.Text = captcha.CaptchaText;
            bitmapCaptcha.Source = captcha.CaptchaImage;
        }

        private int counter = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (captcha.Check(CaptchaBox.Text))
            {
                Close();
                if (actionMode) openAction();
                else openFunc();
            }
            else
            {
                captcha.Generate();
                CaptchaText.Text = captcha.CaptchaText;
                bitmapCaptcha.Source = captcha.CaptchaImage;
                CaptchaBox.Text = string.Empty;
                counter++;
                Click.Content = $"Refresh({counter})";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void CaptchaBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void CaptchaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(CaptchaBox.Text.Length == 0)
            {
                Click.Content = $"Refresh({counter})";
            }
            else
            {
                Click.Content = "Check";
            }
        }
    }
}
