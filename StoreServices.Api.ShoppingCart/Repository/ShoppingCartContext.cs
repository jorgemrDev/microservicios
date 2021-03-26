using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Models;
//dotnet ef migrations add Initial --project StoreServices.Api.ShoppingCart
//dotnet ef database update --project StoreServices.Api.ShoppingCart

namespace StoreServices.Api.ShoppingCart.Repository
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options) { }

        public DbSet<Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartDetail> ShoppingCartDetail { get; set; }

    }
}

