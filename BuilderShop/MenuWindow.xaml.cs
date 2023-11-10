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

namespace BuilderShop
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage();
            fFrame.Navigate(productPage);
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserPage userPage = new UserPage();
            fFrame.Navigate(userPage);
        }

        private void BtnSales_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddSale_Click(object sender, RoutedEventArgs e)
        {
            AddSalePage addSalePage = new AddSalePage();
            fFrame.Navigate(addSalePage);
        }
    }
}
