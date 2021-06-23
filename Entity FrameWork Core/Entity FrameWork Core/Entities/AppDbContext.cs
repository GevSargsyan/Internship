using Entity_FrameWork_Core.FluentApiConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Entities
{
    public class AppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Customer> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new CustomerConfigs());
            modelBuilder.ApplyConfiguration(new InventoryConfigs());
            modelBuilder.ApplyConfiguration(new OrderConfigs());
            modelBuilder.ApplyConfiguration(new OrderHistoryConfigs());
            modelBuilder.ApplyConfiguration(new ProductConfigs());
            modelBuilder.ApplyConfiguration(new ProductListConfigs());
            modelBuilder.ApplyConfiguration(new SaleConfigs());
            

            base.OnModelCreating(modelBuilder); 
        }

    }

}
