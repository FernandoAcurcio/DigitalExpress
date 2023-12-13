using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> ListAllAsync();
        public Task<T> GetEntityWithSpec(ISpecification<T> specification);
        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

    }
}
