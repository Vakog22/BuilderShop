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
using static BuilderShop.DBHelper;

namespace BuilderShop
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            List<Product> products = Context.Product.ToList();
            dgProds.ItemsSource = products;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow productAddWindow = new ProductAddWindow();
            productAddWindow.Show();
            List<Product> products = Context.Product.ToList();
            dgProds.ItemsSource = products;
        }

        private void BtnSV_Click(object sender, RoutedEventArgs e)
        {
            Context.SaveChanges();
            List<Product> products = Context.Product.ToList();
            dgProds.ItemsSource = products;
        }

        private void BtnDetele_Click(object sender, RoutedEventArgs e)
        {
            Product product = (dgProds.SelectedItem as Product);
            Context.Product.Remove(product);
            Context.SaveChanges();
            List<Product> products = Context.Product.ToList();
            dgProds.ItemsSource = products;
        }
    }
}
