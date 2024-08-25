using AutoMapper;
using Core.Entities;
using Core.Entities.OrdenCompra;

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

            CreateMap<Core.Entities.Direccion, DireccionDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<DireccionDto, Core.Entities.OrdenCompra.Direccion>();
            CreateMap<OrdenCompras, OrdenCompraResponseDto>()
                .ForMember(p => p.TipoEnvio, x => x.MapFrom(y => y.TipoEnvio.Nombre))
                .ForMember(p => p.TipoEnvioPrecio, x => x.MapFrom(y => y.TipoEnvio.Precio));

            CreateMap<OrdenItem, OrdenItemResponseDto>()
                .ForMember(p => p.ProductoId, x => x.MapFrom(y => y.ItemOrdenado.ProductoItemId))
                .ForMember(p => p.ProductoNombre, x => x.MapFrom(y => y.ItemOrdenado.ProductoNombre))
                .ForMember(p => p.ProductoImagen, x => x.MapFrom(y => y.ItemOrdenado.ImagenUrl));
        }
    }
}
