using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Libro.Models;
//dotnet ef migrations add Initial --project StoreServices.Api.Libro
//dotnet ef database update --project StoreServices.Api.Libro
//Add-Migration Initial -Project StoreServices.Api.Libro -StartupProject StoreServices.Api.Libro
//Update-Database  -Project StoreServices.Api.Libro -StartupProject StoreServices.Api.Libro

namespace StoreServices.Api.Libro.Repository
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        
    }
}
