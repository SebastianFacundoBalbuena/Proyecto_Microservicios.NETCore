using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Persistence.DataBase.Configuration;

namespace Catalog.Persistence.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductInStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            //Default Schema
            Builder.HasDefaultSchema("Catalog");

            ModelConfig(Builder);
        }

        // Additional configuration 
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            
        }


    }
}
