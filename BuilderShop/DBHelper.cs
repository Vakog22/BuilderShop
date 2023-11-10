using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderShop
{
    class DBHelper
    {
        public static Entities Context { get; } = new Entities();
    }
}
