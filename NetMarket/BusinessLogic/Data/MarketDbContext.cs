

using Core.Entities;
using Core.Entities.OrdenCompra;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BusinessLogic.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Marca> Marca { get; set; }

        public DbSet<OrdenCompras> OrdenCompras { get; set; }

        public DbSet<OrdenItem> OrdenItems { get; set; }

        public DbSet<TipoEnvio> tipoEnvios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
