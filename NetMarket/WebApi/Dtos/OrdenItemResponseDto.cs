using Core.Entities.OrdenCompra;

namespace WebApi.Dtos
{
    public class OrdenItemResponseDto
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }    
        public string ProductoImagen { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
