using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MarcaController : BaseApiController
    {
        private readonly IGenericRepository<Marca> _marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetMarcaAll()
        {
            return Ok(await _marcaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            return await _marcaRepository.GetByIdAsync(id);
        }
    }
}