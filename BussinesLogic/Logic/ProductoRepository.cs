using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinesLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogic.Logic
{
	public class ProductoRepository : IProductoRepository
	{
        private readonly MarketDbContext _context;
		public ProductoRepository(MarketDbContext context)
		{
            _context = context;
		}

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Producto.
                Include(p => p.Marca)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
            
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .ToListAsync();
        }
    }
}

