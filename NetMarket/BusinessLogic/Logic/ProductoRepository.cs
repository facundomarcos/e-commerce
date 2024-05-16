

using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;

        public ProductoRepository(MarketDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Producto.FindAsync(id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Producto.ToListAsync();
        }
    }
}
