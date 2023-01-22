using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }

    }
}
