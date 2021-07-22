using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.Repositories
{
    public class ProductRepository:IProductRepository
    {

        private readonly AppDbContext _db;
        public ProductRepository()
        {
            _db = new AppDbContext();

        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) { throw new Exception("Not Found"); }
            return product;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            var productlist = await _db.Products.ToListAsync();

            return productlist;
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product != null)
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

            }
            return;

        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product == null)
            {
                return;
            }


            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var productforupdate = await GetProductByIdAsync(id);
            if (productforupdate == null)
            {
                return;
            }
            productforupdate.ProductName = product.ProductName;
            _db.Products.Update(productforupdate);
            await _db.SaveChangesAsync();

        }
    }


}
