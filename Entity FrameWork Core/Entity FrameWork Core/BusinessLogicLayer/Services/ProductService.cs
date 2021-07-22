using Entity_FrameWork_Core.BusinessLogicLayer.Interfaces;
using Entity_FrameWork_Core.DataAccesLayer.UnitOfWork;
using Entity_FrameWork_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork _unitofwork;
        public ProductService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task GetAndUpdate(int id)
        {
            var product = await _unitofwork.Products.GetProductByIdAsync(id);

            await _unitofwork.Products.UpdateProduct(id,new Product { ProductName="Updated"});
        }


    }
}
