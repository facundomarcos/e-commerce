using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(string sort)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
            // AddOrderBy(p => p.Nombre);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Nombre);
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
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                        default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }
        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x=> x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }
    }

}
