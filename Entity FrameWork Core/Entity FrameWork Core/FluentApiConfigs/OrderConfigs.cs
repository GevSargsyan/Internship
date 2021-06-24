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
    public class OrderConfigs : IEntityTypeConfiguration<Order>
    {


        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);


            builder.HasMany(o => o.Products)
                .WithOne(p => p.Order);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerId);
        }
    }

}