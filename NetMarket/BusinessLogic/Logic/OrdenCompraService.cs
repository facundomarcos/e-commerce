using Core.Entities.OrdenCompra;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class OrdenCompraService : IOrdenCompraService
    {
        public Task<OrdenCompras> AddOrdenCompraAsync(string compradorEmail, int tipoENvio, string carritoId, Direccion direccion)
        {
            throw new NotImplementedException();
        }

        public Task<OrdenCompras> GetOrdenComprasByIdAsync(int id, string email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<OrdenCompras>> GetOrdenComprasByUserEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TipoEnvio>> GetTipoEnvios()
        {
            throw new NotImplementedException();
        }
    }
}
