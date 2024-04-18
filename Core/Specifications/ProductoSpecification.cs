using Core.Entities;
using Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoSpecification : BaseSpecification<Producto>
    {
        public ProductoSpecification(ProductoSpecificationParams productoParams)

         : base (
                  x  =>


            // si alguno de estos tiene valores, filtrara en la consulta     

            (string.IsNullOrEmpty(productoParams.Nombre) || x.Nombre == productoParams.Nombre) 
             &&
            (string.IsNullOrEmpty(productoParams.Search) || x.Descripcion.Contains(productoParams.Search) || x.Nombre.Contains(productoParams.Search))

        ) // fin base 


        {
            // propiedad de navegacion Producto
            AddInclude(p => p.Marca);

            //  de base specification para paginar 
            ApplyPaging(productoParams.PageSize * (productoParams.PageIndex - 1), productoParams.PageSize);


            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(u => u.Descripcion);
                        break;

                    case "nombreDesc":
                        AddOrderByDescending(u => u.Descripcion);
                        break;
                    case "EstantelAsc":
                        AddOrderBy(u => u.Nombre);
                        break;
                    case "EstantelDes":
                        AddOrderByDescending(u => u.Nombre);
                        break;
                    default:
                        AddOrderBy(u => u.Descripcion);
                        break;

                }
            }


        }
 
    }
}
