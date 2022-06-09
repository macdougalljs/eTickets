using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context
        {
            get; set;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            // check the session to see if we already have a cart with that cart ID, or we'll need to generate it

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            // get the context 

            var context = services.GetService<AppDbContext>();

            // check if we have a cart id session

            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };   
            // get the session using the service provider
        }

        public string ShoppingCartId
        {
            get; set;
        }
        public List<ShoppingCartItem> ShoppingCartItems
        {
            get; set;
        }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            // does the movie already exist in the cart

            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                // create a new item
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1,
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            // does the movie already exist in the cart

            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);

                }
                _context.SaveChanges();
            }
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);

            await _context.SaveChangesAsync();

            ShoppingCartItems = new List<ShoppingCartItem>();  // clears the list by creating a new object

        }
       
    }

}

