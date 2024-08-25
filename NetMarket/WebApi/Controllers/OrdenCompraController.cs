using AutoMapper;
using Core.Entities.OrdenCompra;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Authorize]
    public class OrdenCompraController : BaseApiController
    {
        private readonly IOrdenCompraService _ordenCompraService;
        private readonly IMapper _mapper;

        public OrdenCompraController(
            IOrdenCompraService ordenCompra,
            IMapper mapper
            )
        {
            _ordenCompraService = ordenCompra;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<OrdenCompras>> AddOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var direccion = _mapper.Map<DireccionDto, Direccion>(ordenCompraDto.DireccionEnvio);
            var ordenCompra = await _ordenCompraService.AddOrdenCompraAsync(email, ordenCompraDto.TipoEnvio, ordenCompraDto.CarritoCompraId,direccion);
            
            if(ordenCompra == null) return BadRequest(new CodeErrorResponse(400, "Errores creando la orden de compra"));

            return Ok(ordenCompra);
        
        }

    }


}
