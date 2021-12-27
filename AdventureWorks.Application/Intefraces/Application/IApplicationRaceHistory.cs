using AdventureWorks.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Intefraces
{
    public interface IApplicationRaceHistory
    {
        IEnumerable<RaceHistoryDTO> GetAllAsync();
        IEnumerable<RaceHistoryDTO> ListDetails();
        RaceHistoryDTO ListDetails(int id);
        RaceHistoryDTO GetByIdAsync(int id);
        Task<int> CreateAsync(RaceHistoryDTO entity);
        Task<int> UpdateAsync(RaceHistoryDTO entity);
        Task<int> DeleteAsync(int id);
    }
}
