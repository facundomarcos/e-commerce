using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrdenCompra
{
    public enum OrdenStatus
    {
        [EnumMember(Value = "Pendiente")]
        Pendiente,
        [EnumMember(Value = "El pago fue recibido")]
        PagoRecibido,
        [EnumMember(Value = "El pago tuvo errores")]
        PagoFallo
    }
}
