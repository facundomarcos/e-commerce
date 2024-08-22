namespace WebApi.Dtos
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }  
        public bool Admin { get; set; }
    }
}
