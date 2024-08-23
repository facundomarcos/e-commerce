using Core.Entities.OrdenCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrdenCompraService
    {
        Task<OrdenCompras> AddOrdenCompraAsync(string compradorEmail, int tipoENvio, string carritoId, Direccion direccion);
    
        Task<IReadOnlyList<OrdenCompras>> GetOrdenComprasByUserEmailAsync(string email);

        Task<OrdenCompras> GetOrdenComprasByIdAsync(int id, string email);

        Task<IReadOnlyList<TipoEnvio>> GetTipoEnvios();
    
    }
}
