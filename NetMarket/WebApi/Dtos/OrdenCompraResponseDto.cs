
using System.Collections.Generic;
using System;
using Core.Entities.OrdenCompra;

namespace WebApi.Dtos
{
    public class OrdenCompraResponseDto
    {
        public int Id { get; set; } 
        public string CompradorEmail { get; set; }
        public DateTimeOffset OrdenCompraFecha { get; set; } 
        public Direccion DireccionEnvio { get; set; }
        public string TipoEnvio { get; set; }
        public decimal TipoEnvioPrecio { get; set; }
        public IReadOnlyList<OrdenItemResponseDto> OrdenItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } 
    }
}
