using Entity_FrameWork_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductAsync();
        Task CreateProductAsync(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);


    }
}
