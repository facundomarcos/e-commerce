using Core.Entities.OrdenCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrdenCompraWithItemsSpecification : BaseSpecification<OrdenCompras>
    {
        public OrdenCompraWithItemsSpecification(string email) : base(o =>
            o.CompradorEmail == email)
        {
            AddInclude(o => o.OrdenItems);
            AddInclude(o => o.TipoEnvio);
            AddOrderByDescending(o => o.OrdenCompraFecha);
        }

    public OrdenCompraWithItemsSpecification(int id, string email) : base(o =>
     o.CompradorEmail == email && o.Id == id)
        {
            AddInclude(o => o.OrdenItems);
            AddInclude(o => o.TipoEnvio);
            AddOrderByDescending(o => o.OrdenCompraFecha);
        }
    }
}
