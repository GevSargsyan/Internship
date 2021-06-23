using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.FluentApiConfigs
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x=>x.ProductName).HasMaxLength(25);  
            builder.Property(x=>x.Description).HasMaxLength(100);

            builder.HasOne(p => p.ProductList)
                .WithMany(l => l.Products)
                .HasForeignKey(p => p.ProductListId);

            builder.HasOne(p => p.Sale)
                .WithOne(s => s.Product);
              
            
            builder.HasOne(p => p.Order)
                .WithMany(o => o.Products);


        }
    }
}
