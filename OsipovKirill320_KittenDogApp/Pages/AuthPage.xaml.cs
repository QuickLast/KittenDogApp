using OsipovKirill320_KittenDogApp.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OsipovKirill320_KittenDogApp.Model;
using System.Data.Common;

namespace OsipovKirill320_KittenDogApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTBx.Text.Trim();
            string password = PasswordTBx.Password.Trim();

            int errCounter = 0;
            if (login.Length == 0 || password.Length == 0)
            {
                errCounter++;
                ErrorTBk.Text = "Введите данные!";
            }
            if (errCounter == 0)
            {
                List<User> users = DBConn.KDEnt.User.ToList();
                User currentUser = users.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (currentUser != null)
                {
                    NavigationService.Navigate(new MainPage());
                }
                else
                {
                    ErrorTBk.Text = "Неверный логин или пароль.";
                }
            }
        }
    }
}
