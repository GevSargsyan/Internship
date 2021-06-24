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
    public class SaleConfigs : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {

            builder.HasKey(s => s.SaleId);

            builder.Property(s => s.Price).IsRequired();


            builder.HasOne(s => s.Product)
                   .WithOne(p => p.Sale)
                   .HasForeignKey<Sale>(s => s.SaleId);

      


               
               


        }
    }
}
