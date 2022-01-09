using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriaController : BaseApiController
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public CategoriaController(IGenericRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategoriaAll()
        {
            return Ok(await _categoriaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }
    }
}