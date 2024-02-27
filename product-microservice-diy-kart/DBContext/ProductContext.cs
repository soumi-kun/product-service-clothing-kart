using Microsoft.EntityFrameworkCore;
using product_api_diy_kart.Model;

namespace product_microservice_diy_kart.DBContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CatalogType> CatalogType { get; set; }
        public DbSet<CatalogBrand> CatalogBrand { get; set; }

        //Adding sample data for Catalog Type and Brand
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>().HasData(
                new CatalogType
                {
                    Id = 1,
                    Name = "Processor",
                    Description = "Processor / CPU",
                },
                new CatalogType
                {
                    Id = 2,
                    Name = "Motherboard",
                    Description = "PC Motherboard",
                },
                new CatalogType
                {
                    Id = 3,
                    Name = "RAM",
                    Description = "Random Access Memory",
                }
              );
            modelBuilder.Entity<CatalogBrand>().HasData(
              new CatalogBrand
              {
                  Id = 1,
                  Name = "Intel",
                  Description = "Processor Brand",
              },
              new CatalogBrand
              {
                  Id = 2,
                  Name = "AMD",
                  Description = "Processor Brand",
              },
              new CatalogBrand
              {
                  Id = 3,
                  Name = "Nvidia",
                  Description = "GPU Brand",
              }
          );

        }

    }
}
