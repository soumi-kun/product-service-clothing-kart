using Microsoft.EntityFrameworkCore;
using product_api_diy_kart.Model;
using product_microservice_diy_kart.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace product_microservice_diy_kart.Repository
{
    public class ProductRepository : IProductRepository
    {
        //private readonly ProductContext _dbContext;
        private readonly ProductDapperContext context;


        //public ProductRepository(ProductContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public ProductRepository(ProductDapperContext context)
        {
            this.context = context;
        }
        //public void DeleteProduct(int productId)
        //{
        //    var product = _dbContext.Products.Find(productId);
        //    _dbContext.Products.Remove(product);
        //    Save();
        //}
        public async Task DeleteProduct(int productId)
        {
            var query = "DELETE FROM Products WHERE Id = @productId";

            using(var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { productId });
            }
        }


        //public Product GetProductById(int ProductId)
        //{
        //    return _dbContext.Products.Find(ProductId);
        //}

        public async Task<Product> GetProductById(int ProductId)
        {
            var query = "SELECT * FROM Products WHERE Id = @ProductId";

            using (var connection = context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { ProductId });
                return product;
            }
        }

        //public IEnumerable<Product> GetProducts()
        //{
        //    return _dbContext.Products.ToList();
        //}
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var query = "SELECT * FROM Products";

            using(var connection = context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }

        }


        //public void InsertProduct(Product product)
        //{
        //    _dbContext.Add(product);
        //    Save();
        //}

        public async Task InsertProduct(Product product)
        {
            var query = "INSERT INTO Products (Name, Description, Price, PictureFileName, PictureUri, CatalogTypeId, CatalogBrandId, AvailableStock, RestockThreshold, MaxStockThreshold, OnReorder) VALUES (@Name, @Description, @Price, @PictureFileName, @PictureUri, @CatalogTypeId, @CatalogBrandId, @AvailableStock, @RestockThreshold, @MaxStockThreshold, @OnReorder)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name);
            parameters.Add("Description", product.Description);
            parameters.Add("Price", product.Price);
            parameters.Add("PictureFileName", product.PictureFileName);
            parameters.Add("PictureUri", product.PictureUri);
            parameters.Add("CatalogTypeId", product.CatalogTypeId);
            parameters.Add("CatalogBrandId", product.CatalogBrandId);
            parameters.Add("AvailableStock", product.AvailableStock);
            parameters.Add("RestockThreshold", product.RestockThreshold);
            parameters.Add("MaxStockThreshold", product.MaxStockThreshold);
            parameters.Add("OnReorder", product.OnReorder);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }

        public void Save()
        {
            //_dbContext.SaveChanges();
        }

        //public void UpdateProduct(Product product)
        //{
        //    _dbContext.Entry(product).State = EntityState.Modified;
        //    Save();
        //}

        public async Task UpdateProduct(Product product)
        {
            var query = "UPDATE Products SET Name=@Name, Description=@Description, Price=@Price, PictureFileName=@PictureFileName, PictureUri=@PictureUri, CatalogTypeId=@CatalogTypeId, CatalogBrandId=@CatalogBrandId, AvailableStock=@AvailableStock, RestockThreshold=@RestockThreshold, MaxStockThreshold=@MaxStockThreshold, OnReorder=@OnReorder WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", product.Id, DbType.Int32);
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("Price", product.Price, DbType.Decimal);
            parameters.Add("PictureFileName", product.PictureFileName, DbType.String);
            parameters.Add("PictureUri", product.PictureUri, DbType.String);
            parameters.Add("CatalogTypeId", product.CatalogTypeId, DbType.Int32);
            parameters.Add("CatalogBrandId", product.CatalogBrandId, DbType.Int32);
            parameters.Add("AvailableStock", product.AvailableStock, DbType.Int32);
            parameters.Add("RestockThreshold", product.RestockThreshold, DbType.Int32);
            parameters.Add("MaxStockThreshold", product.MaxStockThreshold, DbType.Int32);
            parameters.Add("OnReorder", product.OnReorder, DbType.Boolean);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
