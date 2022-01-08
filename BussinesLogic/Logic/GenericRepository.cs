using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinesLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogic.Logic
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
	{
        private readonly MarketDbContext _context;

		public GenericRepository(MarketDbContext context)
		{
            _context = context;
		}

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}

