using Core.Entities;
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
        private readonly IGenericRepository<OrdenCompras> _ordenCompraRepository;
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly ICarritoCompraRepository _carritoCompraRepository;
        private readonly IGenericRepository<TipoEnvio> _tipoEnvioRepository;

        public OrdenCompraService(
            IGenericRepository<OrdenCompras> ordenCompraRepository, 
            IGenericRepository<Producto> productoRepository, 
            ICarritoCompraRepository carritoCompraRepository, 
            IGenericRepository<TipoEnvio> tipoEnvioRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _productoRepository = productoRepository;
            _carritoCompraRepository = carritoCompraRepository;
            _tipoEnvioRepository = tipoEnvioRepository;
        }

        public async Task<OrdenCompras> AddOrdenCompraAsync(
                                                string compradorEmail, 
                                                int tipoENvio, 
                                                string carritoId, 
                                                Core.Entities.OrdenCompra.Direccion direccion)
        {
            //obtener el carrito de compra
            var carritoCompra = await _carritoCompraRepository.GetCarritoCompraAsync(carritoId);
            //obtener los items y detalle de cada producto item
            var items = new List<OrdenItem>();
            foreach (var item in carritoCompra.Items)
            {
                var productoItem =await _productoRepository.GetByIdAsync(item.Id);
                var itemOrdenado = new ProductoItemOrdenado(productoItem.Id, productoItem.Nombre, productoItem.Imagen);
                var ordenItem = new OrdenItem(itemOrdenado, productoItem.Precio,item.Cantidad);
                items.Add(ordenItem);
            }
            
            //obtener el tipo de envio
            var tipoEnvioEntity = await _tipoEnvioRepository.GetByIdAsync(tipoENvio);
            //calcular el subtotal a pagar
            var subtotal = items.Sum(item => item.Precio * item.Cantidad);
            //crear la orden de compra
            var ordenCompra = new OrdenCompras(compradorEmail, direccion, tipoEnvioEntity, items, subtotal);
            //almacenar la orden de compra

            //retornar la orden de compra
            return ordenCompra;

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
