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
using static BuilderShop.DBHelper;

namespace BuilderShop
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        public ProductAddWindow()
        {
            InitializeComponent();
            List<Group> groups = Context.Group.ToList();
            List<Manufacturer> manufacturers = Context.Manufacturer.ToList();
            cmbGroup.ItemsSource = groups;
            cmbManufacturer.ItemsSource = manufacturers;
            cmbGroup.DisplayMemberPath = "Title";
            cmbGroup.SelectedIndex = 0;
            cmbManufacturer.DisplayMemberPath = "Name";
            cmbManufacturer.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.Title = tbTitle.Text;
                product.Height = Convert.ToDecimal(tbHeight.Text);
                product.Width = Convert.ToDecimal(tbWidth.Text);
                product.Length = Convert.ToDecimal(tbLength.Text);
                product.Quantity = Convert.ToInt32(tbQuantity.Text);
                product.IdManufacturer = (cmbManufacturer.SelectedItem as Manufacturer).Id;
                product.IdGroup = (cmbGroup.SelectedItem as Group).Id;
                Context.Product.Add(product);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
