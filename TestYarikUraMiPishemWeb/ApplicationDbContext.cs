using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestYarikUraMiPishemWeb.Entities;

namespace TestYarikUraMiPishemWeb
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
