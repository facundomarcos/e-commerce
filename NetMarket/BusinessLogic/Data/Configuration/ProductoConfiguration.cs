

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Imagen).HasMaxLength(1000);
            builder.Property(p => p.Precio).HasColumnType("decimal(18,2)");
            builder.HasOne(m => m.Marca).WithMany().HasForeignKey(p => p.MarcaId);
            builder.HasOne(c => c.Categoria).WithMany().HasForeignKey(p => p.CategoriaId);
        }
    }

}
