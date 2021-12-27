using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Core.Services;
using AdventureWorks.Domain.DTO;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Services
{
    public class RaceHistoryService : ServiceBase<RaceHistory>, IServiceRaceHistory
    {
        private readonly IRepositoryRaceHistory _repositoryRaceHistory;
        public RaceHistoryService(IRepositoryRaceHistory repositoryRaceHistory)
            : base(repositoryRaceHistory)
        {
            _repositoryRaceHistory = repositoryRaceHistory;
        }

        public Task<IEnumerable<RaceHistoryDTO>> ListDetailsHistory()
        {
            return _repositoryRaceHistory.ListDetailsHistory();
        }

        public Task<RaceHistoryDTO> ListDetailsHistoryById(int id)
        {
            return _repositoryRaceHistory.ListDetailsHistoryById(id);
        }

    }
}
