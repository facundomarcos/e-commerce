using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrdenCompra
{
    public class OrdenItem : ClaseBase
    {
        public OrdenItem()
        {
            
        }
        public OrdenItem(ProductoItemOrdenado itemOrdenado, decimal precio, int cantidad)
        {
            this.ItemOrdenado = itemOrdenado;
            Precio = precio;
            Cantidad = cantidad;
        }

        public ProductoItemOrdenado ItemOrdenado { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
