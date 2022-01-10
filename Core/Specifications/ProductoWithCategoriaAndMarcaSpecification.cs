using System;
using Core.Entities;

namespace Core.Specifications
{
	public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
	{

		public ProductoWithCategoriaAndMarcaSpecification(ProductoSepecificationParams productoParams)
			: base(x =>

				(string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
				(!productoParams.Marca.HasValue || x.MarcaId == productoParams.Marca) &&
				(!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria)
			)
		{
			// Relacions de entidades
			AddInclude(p => p.Categoria);
			AddInclude(p => p.Marca);
			// Aplicamos la Paginación
			ApplyPaging(productoParams.PageSize * (productoParams.PageIndex - 1), productoParams.PageSize);

			if(!string.IsNullOrEmpty(productoParams.Sort))
            {
				switch(productoParams.Sort)
                {
					case "nombreAsc":
						AddOrderBy(p => p.Nombre);
						break;
					case "nombreDesc":
						AddOrderByDescending(p => p.Nombre);
						break;
					case "marcaAsc":
						AddOrderBy(p => p.Marca);
						break;
					case "marcaDesc":
						AddOrderByDescending(p => p.Marca);
						break;
					case "precioAsc":
						AddOrderBy(p => p.Precio);
						break;
					case "precioDesc":
						AddOrderByDescending(p => p.Precio);
						break;
					case "descripcionAsc":
						AddOrderBy(p => p.Descripcion);
						break;
					case "descriptionDesc":
						AddOrderByDescending(p => p.Descripcion);
						break;
					default:
						AddOrderBy(p => p.Nombre);
						break;

				}
            }
		}

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id)
        {
			AddInclude(p => p.Categoria);
			AddInclude(p => p.Marca);
		}
	}
}

