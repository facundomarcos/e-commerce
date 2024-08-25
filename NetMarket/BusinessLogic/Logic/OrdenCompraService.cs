using Core.Entities;
using Core.Entities.OrdenCompra;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class OrdenCompraService : IOrdenCompraService
    {
        //private readonly IGenericRepository<OrdenCompras> _ordenCompraRepository;
        //private readonly IGenericRepository<Producto> _productoRepository;
        private readonly ICarritoCompraRepository _carritoCompraRepository;
        //private readonly IGenericRepository<TipoEnvio> _tipoEnvioRepository;

        private readonly IUnitOfWork _unitOfWork;

        //public OrdenCompraService(
        //    IGenericRepository<OrdenCompras> ordenCompraRepository, 
        //    IGenericRepository<Producto> productoRepository, 
        //    ICarritoCompraRepository carritoCompraRepository, 
        //    IGenericRepository<TipoEnvio> tipoEnvioRepository)
        //{
        //    _ordenCompraRepository = ordenCompraRepository;
        //    _productoRepository = productoRepository;
        //    _carritoCompraRepository = carritoCompraRepository;
        //    _tipoEnvioRepository = tipoEnvioRepository;
        //}

        public OrdenCompraService(
            ICarritoCompraRepository carritoCompraRepository,
            IUnitOfWork unitOfWork)
        {
            _carritoCompraRepository = carritoCompraRepository;
            _unitOfWork = unitOfWork;
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
                var productoItem =await _unitOfWork.Repository<Producto>().GetByIdAsync(item.Id);
                var itemOrdenado = new ProductoItemOrdenado(productoItem.Id, productoItem.Nombre, productoItem.Imagen);
                var ordenItem = new OrdenItem(itemOrdenado, productoItem.Precio,item.Cantidad);
                items.Add(ordenItem);
            }
            
            //obtener el tipo de envio
            var tipoEnvioEntity = await _unitOfWork.Repository<TipoEnvio>().GetByIdAsync(tipoENvio);
            //calcular el subtotal a pagar
            var subtotal = items.Sum(item => item.Precio * item.Cantidad);
            //crear la orden de compra
            var ordenCompra = new OrdenCompras(compradorEmail, direccion, tipoEnvioEntity, items, subtotal);
            //almacenar la orden de compra
            _unitOfWork.Repository<OrdenCompras>().AddEntity(ordenCompra);
            var resultado = await _unitOfWork.Complete();
            if (resultado <= 0) { return null; }

            //elimina el carrito
            await _carritoCompraRepository.DeleteCarritoCompraAsync(carritoId);

            //retornar la orden de compra
            return ordenCompra;

        }

        public async Task<OrdenCompras> GetOrdenComprasByIdAsync(int id, string email)
        {
            var spec = new OrdenCompraWithItemsSpecification(id, email);

            return await _unitOfWork.Repository<OrdenCompras>().GetByIdWithSpec(spec);
        }

        public async Task<IReadOnlyList<OrdenCompras>> GetOrdenComprasByUserEmailAsync(string email)
        {
            var spec = new OrdenCompraWithItemsSpecification(email);

            return await _unitOfWork.Repository<OrdenCompras>().GetAllWithSpec(spec);
        }

        public async Task<IReadOnlyList<TipoEnvio>> GetTipoEnvios()
        {
           return await _unitOfWork.Repository<TipoEnvio>().GetAllAsync();
        }
    }
}
