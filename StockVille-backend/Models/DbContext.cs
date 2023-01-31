using Microsoft.EntityFrameworkCore;
using System.Xml;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace StockVille_backend.Models { 
    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
    }
}
