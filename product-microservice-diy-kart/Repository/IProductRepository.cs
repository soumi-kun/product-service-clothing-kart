using product_api_diy_kart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_microservice_diy_kart.Repository
{
    public interface IProductRepository
    {
        //IEnumerable<Product> GetProducts();
        //Product GetProductById(int ProductId);
        //void InsertProduct(Product Product);
        //void DeleteProduct(int ProductId);
        //void UpdateProduct(Product Product);
        Task <IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int ProductId);
        Task InsertProduct(Product Product);
        Task DeleteProduct(int ProductId);
        Task UpdateProduct(Product Product);
        void Save();

    }
}
