

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BusinessLogic.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }

        public DbSet<Producto>  Producto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
