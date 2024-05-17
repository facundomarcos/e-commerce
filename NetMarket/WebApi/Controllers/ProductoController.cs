﻿using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;
        public ProductoController(
            IGenericRepository<Producto> productoRepository,
             IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();

            var productos = await _productoRepository.GetAllWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            //return await _productoRepository.GetByIdAsync(id);
            //spec debe incluir la logica de la condicion de la consulta y tambien las relaciones entre las entidades
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);

            var producto = await _productoRepository.GetByIdWithSpec(spec);
           return _mapper.Map<Producto, ProductoDto>(producto);
        }

    }
}

