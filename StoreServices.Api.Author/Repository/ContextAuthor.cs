using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Autor.Model;
//dotnet ef migrations add Initial --project StoreServices.Api.Author
//dotnet ef database update --project StoreServices.Api.Author
//docker run --name postgres-books -e POSTGRES_PASSWORD=PASS -d -p 5432:5432 postgres:latest
//docker exec -it postgres-books bash
//docker start postgres-books
namespace StoreServices.Api.Author.Repository
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) { 

        }

        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
}
