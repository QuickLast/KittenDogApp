using Microsoft.Win32;
using OsipovKirill320_KittenDogApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace OsipovKirill320_KittenDogApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPhoto.xaml
    /// </summary>
    public partial class AddPhoto : Page
    {
        public static Photo photo = new Photo();
        public static User userToSend = new User();
        public AddPhoto(User user)
        {
            InitializeComponent();
            userToSend = user;
        }

        private void PhotoAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                photo.PhotoSource = File.ReadAllBytes(openFileDialog.FileName);
                PhotoCheck.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(userToSend));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTBx.Text.Trim();
            string description = DescriptionTBx.Text.Trim();
        }
    }
}
