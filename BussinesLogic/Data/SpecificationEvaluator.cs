using System;
using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogic.Data
{
	public class SpecificationEvaluator<T> where T: BaseClass
	{
		public SpecificationEvaluator()
		{
		}
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
		{
			if(spec.Criteria != null)
            {
				inputQuery = inputQuery.Where(spec.Criteria);
            }

			if(spec.OrderBy != null)
            {
				inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }

			if(spec.OrderByDescending != null)
            {
				inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);
			}

			if(spec.IsPagingEnable)
            {
				inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

			inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

			return inputQuery;
		}
	}
}

