using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Core.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class  
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
    }
}
