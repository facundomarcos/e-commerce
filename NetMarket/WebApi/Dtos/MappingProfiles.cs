using AutoMapper;
using Core.Entities;

namespace WebApi.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                //se llena desde la clase Categoria
                .ForMember(p=> p.CategoriaNombre, x=> x.MapFrom(a=> a.Categoria.Nombre ))
                .ForMember(p => p.MarcaNombre, x => x.MapFrom(a => a.Marca.Nombre));

            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<DireccionDto, Core.Entities.OrdenCompra.Direccion>();
        }
    }
}
