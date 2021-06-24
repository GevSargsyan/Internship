using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer
{
    public class ProductService
    {

        private readonly AppDbContext _db;
        public ProductService()
        {
            _db = new AppDbContext();

        }
        
        public async Task<List<Product>> GetProducts()
        {
            var query = from p in _db.Products
                        where p.ProductName == "Apple" && p.DateSold > new DateTime(2018, 10, 20)
                        orderby p.DateSold descending
                        select p;

            var productlist = await query.ToListAsync();

            return productlist;


        }

        public async Task CreateProduct()
        {
            var product = new Product
            {
                ProductName = "Apple",
                Description = "11",
                DateSold = new DateTime(2020, 10, 28),
                ProductListId = 3,

            };

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();



        }

        public async Task UpdateProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product==null)
            {
                return;
            }

            product.Description = "12";
            _db.Products.Update(product);
            await _db.SaveChangesAsync();


        }

        public async Task DeleteProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product==null)
            {
                return;
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();


        }


    }
}
