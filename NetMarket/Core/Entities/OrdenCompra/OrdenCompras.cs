using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrdenCompra
{
    public class OrdenCompras : ClaseBase
    {
        public OrdenCompras() { }

        public OrdenCompras(string compradorEmail, Direccion direccionEnvio, 
            TipoEnvio tipoEnvio, IReadOnlyList<OrdenItem> ordenItems, decimal subtotal)
        {
            CompradorEmail = compradorEmail;
            DireccionEnvio = direccionEnvio;
            TipoEnvio = tipoEnvio;
            OrdenItems = ordenItems;
            Subtotal = subtotal;
        }

        public string CompradorEmail { get; set; }
        public DateTimeOffset OrdenCompraFecha { get; set; } = DateTimeOffset.Now;
        public Direccion DireccionEnvio { get; set; }
        public TipoEnvio TipoEnvio { get; set; }
        public IReadOnlyList<OrdenItem> OrdenItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrdenStatus Status { get; set; } = OrdenStatus.Pendiente;
        public string PagoIntentoId { get; set; }

        public decimal GetTotal (){ 
            return Subtotal + TipoEnvio.Precio; }
    }
}
