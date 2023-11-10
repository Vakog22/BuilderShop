using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static BuilderShop.DBHelper;

namespace BuilderShop
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            List<User> users = DBHelper.Context.User.ToList();
            dgProds.ItemsSource = users;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow productAddWindow = new ProductAddWindow();
            productAddWindow.Show();
            List<User> products = DBHelper.Context.User.ToList();
            dgProds.ItemsSource = products;
        }

        private void BtnSV_Click(object sender, RoutedEventArgs e)
        {
            DBHelper.Context.SaveChanges();
            List<User> products = DBHelper.Context.User.ToList();
            dgProds.ItemsSource = products;
        }

        private void BtnDetele_Click(object sender, RoutedEventArgs e)
        {
            User product = (dgProds.SelectedItem as User);
            DBHelper.Context.User.Remove(product);
            DBHelper.Context.SaveChanges();
            List<User> products = DBHelper.Context.User.ToList();
            dgProds.ItemsSource = products;
        }
    }
}
