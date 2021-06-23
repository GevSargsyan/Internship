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
    public class InventoryConfigs : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasMaxLength(25);

            builder.HasMany(i => i.ProductLists)
                .WithOne(p => p.Inventory);
                
        }
    }
}
