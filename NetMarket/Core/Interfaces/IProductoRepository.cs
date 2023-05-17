

using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> GetProductoByIdAsync(int id);

        Task<IReadOnlyList<Producto>> GetProductosAsync();
    }
}
