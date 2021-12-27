using AdventureWorks.Domain.DTO;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Core.Interfaces
{
    public interface IRepositoryRaceHistory : IRepositoryBase<RaceHistory>
    {
        Task<IEnumerable<RaceHistoryDTO>> ListDetailsHistory();
        Task<RaceHistoryDTO> ListDetailsHistoryById(int id);
        
    }
}
