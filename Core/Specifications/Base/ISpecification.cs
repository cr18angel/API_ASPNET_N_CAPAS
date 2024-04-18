using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Base
{
    public interface ISpecification<T>
    {
        //Conidion logica de la entidad 
        Expression<Func<T, bool>> Criteria { get; }

        //la relacion 
        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }


        //cantidad de elementos que toma
        int Take { get; }
        // representa la posicion 
        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}
