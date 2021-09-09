using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Client.Models;

namespace Shopping.Client.Services
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(Product productDto, string token);
        Task<T> UpdateProductAsync<T>(Product productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
