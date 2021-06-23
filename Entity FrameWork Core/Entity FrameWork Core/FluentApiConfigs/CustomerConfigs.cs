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
    public class CustomerConfigs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.Name).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(20);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer);

            builder.HasOne(c => c.OrderHistory)
                .WithOne(o => o.Customer);
                


        }
    }
}
