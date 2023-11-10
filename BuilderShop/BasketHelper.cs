using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuilderShop.DBHelper;

namespace BuilderShop
{
    internal class BasketHelper
    {
        public static ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
