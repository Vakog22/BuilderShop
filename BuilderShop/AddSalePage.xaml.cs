using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddSalePage.xaml
    /// </summary>
    public partial class AddSalePage : Page
    {
        public AddSalePage()
        {
            InitializeComponent();
            GetProduct();
        }

        private void GetProduct()
        {
            ObservableCollection<Product> ProdList = new ObservableCollection<Product>(DBHelper.Context.Product.ToList());

            LVEmp.ItemsSource = ProdList;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Product selectedProduct = button.DataContext as Product;
            if (selectedProduct != null)
            {
                for (int i = 0; i < BasketHelper.Products.Count; i++)
                {
                    if (BasketHelper.Products[i] == selectedProduct)
                    {
                        BasketHelper.Products[i].Quantity = 0;
                    }
                }
                BasketHelper.Products.Remove(selectedProduct);
            }
            GetProduct();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Product selectedProduct = button.DataContext as Product;
            if (selectedProduct != null)
            {
                for (int i = 0; i < BasketHelper.Products.Count; i++)
                {
                    if (BasketHelper.Products[i] == selectedProduct)
                    {
                        BasketHelper.Products[i].Quantity--;
                    }
                }
                if (selectedProduct.Quantity == 0)
                {
                    BasketHelper.Products.Remove(selectedProduct);
                }
            }
            GetProduct();
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            bool seek = true;
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Product selectedProduct = button.DataContext as Product;
            if (selectedProduct != null)
            {
                for (int i = 0; i < BasketHelper.Products.Count; i++)
                {
                    if (BasketHelper.Products[i] == selectedProduct)
                    {
                        BasketHelper.Products[i].Quantity++;
                        seek = false;
                    }
                }
                if (seek)
                {
                    selectedProduct.Quantity = +1;
                    BasketHelper.Products.Add(selectedProduct);
                }
            }
            GetProduct();
        }
    }
}
