using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BlogDB;Integrated Security = True");
        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
    }
}
