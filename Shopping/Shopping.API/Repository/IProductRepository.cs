using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.API.Models;

namespace Shopping.API.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(); // we use Task<> since we want to return asyn using await
        Task<Product> GetProductById(int productId);
        Task<Product> CreateUpdateProduct(Product productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
