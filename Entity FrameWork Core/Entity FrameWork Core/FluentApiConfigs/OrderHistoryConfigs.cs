using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_FrameWork_Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_FrameWork_Core.FluentApiConfigs
{
    public class OrderHistoryConfigs : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(o => o.OrderHistoryId);

            builder.HasOne(o => o.Customer)
                .WithOne(c => c.OrderHistory);



        }
    }
}
