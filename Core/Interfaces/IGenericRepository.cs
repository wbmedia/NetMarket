﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseClass
    {
		Task<T> GetByIdAsync(int id);

		Task<IReadOnlyList<T>> GetAllAsync();

		Task<T> GetByIdWithSpec(ISpecification<T> spec);

		Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec); 
	}
}

