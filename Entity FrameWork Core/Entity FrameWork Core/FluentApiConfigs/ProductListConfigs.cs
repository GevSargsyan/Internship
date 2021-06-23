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
    public class ProductListConfigs : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {

            builder.HasKey(p => p.ProductListId);

            builder.Property(p => p.Name).HasMaxLength(25);

            builder.HasOne(p => p.Inventory)
                .WithMany(i => i.ProductLists)
                .HasForeignKey(p=>p.InventoryId);

            builder.HasMany(p => p.Products)
                .WithOne(p => p.ProductList);
              
                


        }
    }
}
