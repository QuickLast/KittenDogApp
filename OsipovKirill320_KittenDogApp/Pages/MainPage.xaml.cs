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
        public MainPage(User user)
        {
            InitializeComponent();
            if (user.IDUser == 1)
                PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.ForUser == 1).ToList();
            if (user.IDUser == 2)
                PhotoLV.ItemsSource = DBConn.KDEnt.Photo.Where(i => i.ForUser == 2).ToList();
        }

        private void SortTBx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
