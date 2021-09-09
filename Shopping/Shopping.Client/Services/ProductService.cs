using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shopping.Client.Models;

namespace Shopping.Client.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<T> CreateProductAsync<T>(Product productDto, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteProductAsync<T>(int id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/product",
                AccessToken = token
            });
        }

        public Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateProductAsync<T>(Product productDto, string token)
        {
            throw new NotImplementedException();
        }
    }
}
