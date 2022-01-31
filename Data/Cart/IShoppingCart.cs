using Etheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Cart
{
    public interface IShoppingCart
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public void RemoveItemFromCart(Movie movie);
        public void AddItemsToCart(Movie movie);
        public Double GetShoppingTotal();
        public List<ShoppingCartItem> GetShoppingCartItems();

    }
}
