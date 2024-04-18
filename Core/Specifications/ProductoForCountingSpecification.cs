using Core.Entities;
using Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoForCountingSpecification : BaseSpecification <Producto>
    {
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams) : base(
            
            x =>


            (string.IsNullOrEmpty(productoParams.Nombre) || x.Nombre == productoParams.Nombre)
             &&
            (string.IsNullOrEmpty(productoParams.Search) || x.Descripcion.Contains(productoParams.Search) || x.Nombre.Contains(productoParams.Search))


            ) // fin base 
        {
            
        }
    }
}
