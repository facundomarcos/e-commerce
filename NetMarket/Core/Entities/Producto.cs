namespace Core.Entities
{
    public class Producto : ClaseBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public Marca Marca { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        //[Column(TypeName ="decimal(18,4)")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
