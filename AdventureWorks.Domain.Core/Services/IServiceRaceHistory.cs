using AdventureWorks.Domain.DTO;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Core.Services
{
    public interface IServiceRaceHistory : IServiceBase<RaceHistory>
    {
        Task<IEnumerable<RaceHistoryDTO>> ListDetailsHistory();
        Task<RaceHistoryDTO> ListDetailsHistoryById(int id);
    }
}
