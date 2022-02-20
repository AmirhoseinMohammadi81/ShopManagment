using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping:IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UnitPrice).IsRequired().HasMaxLength(255);
            builder.OwnsMany(x =>x.InventoryOperations,modelbuilder=>
            {
                modelbuilder.ToTable("InventoryOperations");
                modelbuilder.HasKey(x => x.Id);
                modelbuilder.Property(x => x.Description).HasMaxLength(510);
                modelbuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });
           
             
        }
    }
}
