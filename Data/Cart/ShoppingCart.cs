using Etheater.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Data.Cart
{
    public class ShoppingCart:IShoppingCart
    {
        public AppDbContext Context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        IHttpContextAccessor it;
        public ShoppingCart(AppDbContext _Context, IHttpContextAccessor itt)
        {
            Context = _Context;
            it = itt;
            ISession session=itt.HttpContext.Session;
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            ShoppingCartId = cartId;

        }


      
        //Removing Item From Cart

        public void RemoveItemFromCart(Movie movie) {
        var ShoppingCartItem = Context.ShoppingCardItems.
        FirstOrDefault(n => n.Movies.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {

                    ShoppingCartItem.Amount--;
                }

                else
                {
                    Context.ShoppingCardItems.Remove(ShoppingCartItem);
                }
            }
            Context.SaveChanges();
        }

        



        //Adding Item to Cart
        public void AddItemsToCart(Movie movie) {

            var ShoppingCartItem = Context.ShoppingCardItems.FirstOrDefault(n => n.Movies.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (ShoppingCartItem==null)
            {
                ShoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movies = movie,
                    Amount = 1

                };
                Context.ShoppingCardItems.Add(ShoppingCartItem);
            }

            else
            {
                ShoppingCartItem.Amount ++ ;
            }
            Context.SaveChanges();
        
        }



        //Getting Total shopping Cart Item
        public Double GetShoppingTotal()=>Context.ShoppingCardItems.
         Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movies.Price * n.Amount).Sum();



        //Getting List Of shopping Cart Item
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = Context.ShoppingCardItems.Where(n => n.ShoppingCartId 
            == ShoppingCartId).Include(n => n.Movies).ToList());
        }

    }
}
