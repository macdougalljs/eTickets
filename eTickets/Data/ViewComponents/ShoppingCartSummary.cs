using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Data.ViewComponents
{

    public class ShoppingCartSummary : ViewComponent
    {
        //inject the shopping cart

        private readonly ShoppingCart _shoppingcart;

        public ShoppingCartSummary(ShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            return View(items.Count);
        }

    }
}
