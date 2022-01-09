using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
       private readonly IGenericRepository<Producto> _productoRespository;
       private readonly IMapper _mapper; 

       public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
       {
            _productoRespository = productoRepository;
            _mapper = mapper;
       }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await _productoRespository.GetAllWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            var producto = await _productoRespository.GetByIdWithSpec(spec);

            if(producto == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            return _mapper.Map<Producto, ProductoDto>(producto);
        }

    }
}