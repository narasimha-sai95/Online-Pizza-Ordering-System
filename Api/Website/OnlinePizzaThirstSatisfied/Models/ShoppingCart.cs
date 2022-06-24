using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlinePizzaThirstSatisfied.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlinePizzaThirstSatisfied.Models
{
    
        public class ShoppingCart
        {
        private readonly PizzaDbContext _pizzaDbContext;

        private ShoppingCart(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }
        public string ShoppingCartId { get; set; }

            public List<ShoppingCartItem> ShoppingCartItems { get; set; }


            public static ShoppingCart GetCart(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

                var context = services.GetService<PizzaDbContext>();
                string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

                session.SetString("CartId", cartId);

                return new ShoppingCart(context) { ShoppingCartId = cartId };
            }

            public async Task AddToCartAsync(Pizzas pizza, int amount)
            {
                var shoppingCartItem =
                        await _pizzaDbContext.ShoppingCartItems.SingleOrDefaultAsync(
                            s => s.Pizza.Id == pizza.Id && s.ShoppingCartId == ShoppingCartId);

                if (shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = ShoppingCartId,
                        Pizza = pizza,
                        Amount = 1
                    };

                _pizzaDbContext.ShoppingCartItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.Amount++;
                }

                await _pizzaDbContext.SaveChangesAsync();
            }

            public async Task<int> RemoveFromCartAsync(Pizzas pizza)
            {
                var shoppingCartItem =
                        await _pizzaDbContext.ShoppingCartItems.SingleOrDefaultAsync(
                            s => s.Pizza.Id == pizza.Id && s.ShoppingCartId == ShoppingCartId);

                var localAmount = 0;

                if (shoppingCartItem != null)
                {
                    if (shoppingCartItem.Amount > 1)
                    {
                        shoppingCartItem.Amount--;
                        localAmount = shoppingCartItem.Amount;
                    }
                    else
                    {
                    _pizzaDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    }
                }

                await _pizzaDbContext.SaveChangesAsync();

                return localAmount;
            }

            public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
            {
                return ShoppingCartItems ??
                       (ShoppingCartItems = await
                          _pizzaDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                               .Include(s => s.Pizza)
                               .ToListAsync());
            }

            public async Task ClearCartAsync()
            {
                var cartItems = _pizzaDbContext
                    .ShoppingCartItems
                    .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _pizzaDbContext.ShoppingCartItems.RemoveRange(cartItems);

                await _pizzaDbContext.SaveChangesAsync();
            }

            public decimal GetShoppingCartTotal()
            {
                var total = _pizzaDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Select(c => c.Pizza.price * c.Amount).Sum();
                return total;
            }

        }
    }
