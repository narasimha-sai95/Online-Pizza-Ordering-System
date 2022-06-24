using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlinePizzaThirstSatisfied.Models;

namespace OnlinePizzaThirstSatisfied.Data
{
    public class PizzaDbContext : IdentityDbContext<IdentityUser>
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {
        }

        public DbSet<Pizzas> Pizzas { get; set; } 
        public DbSet<UserReviews> UserReviews { get; set; }

        public DbSet<ShoppingCartItem>ShoppingCartItems { get; set; }
    }
}
