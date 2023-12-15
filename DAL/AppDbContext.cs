using ExamWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }    
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
