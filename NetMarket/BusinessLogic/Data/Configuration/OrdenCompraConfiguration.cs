using Core.Entities.OrdenCompra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class OrdenCompraConfiguration : IEntityTypeConfiguration<OrdenCompras>
    {
        public void Configure(EntityTypeBuilder<OrdenCompras> builder)
        {
            //no puede existir una direccion si antes no existe una orden de compra
            builder.OwnsOne(o => o.DireccionEnvio, x =>
            {
                x.WithOwner();
            });

            builder.Property(s => s.Status)
                .HasConversion(
                o => o.ToString(),
                o => (OrdenStatus)Enum.Parse(typeof(OrdenStatus), o)
                );
            //cuando elimina la orden de compra, se eliminan los items
            builder.HasMany(o => o.OrdenItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
