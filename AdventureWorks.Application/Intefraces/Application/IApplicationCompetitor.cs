using AdventureWorks.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Intefraces
{
    public interface IApplicationCompetitor
    {
        IEnumerable<CompetitorDTO> GetAllAsync();
        CompetitorDTO GetByIdAsync(int id);
        Task<int> CreateAsync(CompetitorDTO entity);
        Task<int> UpdateAsync(CompetitorDTO entity);
        Task<int> DeleteAsync(int id);
    }
}
