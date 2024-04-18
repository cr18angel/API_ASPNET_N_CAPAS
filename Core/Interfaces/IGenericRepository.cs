using Core.Entities;
using Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {
        Task<T> GetByIdAsync(string id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);


        //paginacion
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> GetByIdNumberAsync(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        void AddEntity(T Entity);
        void UpdateEntity(T Entity);
        void DeleteEntity(T Entity);
        Task<int> SaveAsync();

        //Task<int> Add(T entity);

        //Task<int> Update(T entity);

        //void AddEntity(T Entity);

        //void UpdateEntity(T Entity);

        //void DeleteEntity(T Entity);

    }
}
