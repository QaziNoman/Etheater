using Etheater.Data.Cart;
using Etheater.Data.Services;
using Etheater.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService MovieServices;
        private readonly IShoppingCart _ShoppingCart;
        public OrdersController(IMovieService _MovieServices, IShoppingCart _CartServices)
        {
            _ShoppingCart = _CartServices;
            MovieServices = _MovieServices;
        }
        public IActionResult Index()
        {
            var Item = _ShoppingCart.GetShoppingCartItems();
            //var Shopping
            _ShoppingCart.ShoppingCartItems = Item;
            var response = new ShoppingCartVM
            {
                ShoppingCart = _ShoppingCart,
                Total = _ShoppingCart.GetShoppingTotal()
            };


            return View(response);
        }


        public async Task<RedirectToActionResult>AddToShoppingCart(int id){

            var MovieList = await MovieServices.GetMovieByIdAsync(id);
            if (MovieList != null)
            {
                _ShoppingCart.AddItemsToCart( MovieList);
            }

            return RedirectToAction(nameof(Index));


        }


        public async Task<RedirectToActionResult> RemoveFromCart(int id)
        {

            var MovieList = await MovieServices.GetMovieByIdAsync(id);
            if (MovieList != null)
            {
                _ShoppingCart.RemoveItemFromCart(MovieList);
            }

            return RedirectToAction(nameof(Index));


        }

    }
}
