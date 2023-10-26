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

namespace OsipovKirill320_KittenDogApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static int userID = 0;
        public static List<Photo> Photos { get; set; }
        public static User userToSend = new User(); 
        public MainPage(User user)
        {
            InitializeComponent();
            userToSend = user;
            if (user.IDUser == 1)
            {
                profileImage.Source = new BitmapImage(new Uri("/Images/pyroProfile.jpg", UriKind.RelativeOrAbsolute));
                WelcomeTBx.Text = "Привет, Пиро!";
                userID = 1;
            }
            if (user.IDUser == 2)
            {
                profileImage.Source = new BitmapImage(new Uri("/Images/delyaProfile.jpg", UriKind.RelativeOrAbsolute));
                WelcomeTBx.Text = "Привет, Деля!";
                userID = 2;
            }
                
            PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.ForUser == userID).ToList();
            Photos = DBConn.KDEnt.Photo.Where(i => i.ForUser == userID).ToList();
            this.DataContext = this;
        }

        private void SortTBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SortTBx.Text.Trim() == "")
                PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.ForUser == userID).ToList();
            else
                PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.Description.Contains(SortTBx.Text.Trim()) && i.ForUser == userID).ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = (SortCB.SelectedItem as Photo).Name;
            PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.Name == t).ToList();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(userToSend));
        }
    }
}
