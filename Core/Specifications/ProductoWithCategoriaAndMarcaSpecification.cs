using System;
using Core.Entities;

namespace Core.Specifications
{
	public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
	{

		public ProductoWithCategoriaAndMarcaSpecification()
		{
			// Relacions de entidades
			AddInclude(p => p.Categoria);
			AddInclude(p => p.Marca);
		}

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id)
        {
			AddInclude(p => p.Categoria);
			AddInclude(p => p.Marca);
		}
	}
}

