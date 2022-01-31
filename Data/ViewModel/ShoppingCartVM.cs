using Etheater.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.ViewModel
{
    public class ShoppingCartVM
    {

        public IShoppingCart ShoppingCart { get; set; }
        public double Total { get; set; }
    }
}
