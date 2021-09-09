using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _db;
        //private IMapper _mapper;

        public ProductRepository(ProductContext db)
        {
            _db = db;
           // _mapper = mapper;
        }

        public async Task<Product> CreateUpdateProduct(Product product)
        {
            //Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.Id > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.Id == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return productList;

        }
    }
}
