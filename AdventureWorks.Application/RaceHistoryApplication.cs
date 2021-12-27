using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application
{
    public class RaceHistoryApplication : IApplicationRaceHistory
    {
        private readonly IServiceRaceHistory _serviceRaceHistory;
        private readonly IMapperRaceHistory _mapperRaceHistory;

        public RaceHistoryApplication(IServiceRaceHistory serviceRaceHistory, IMapperRaceHistory mapperRaceHistory)
        {
            _serviceRaceHistory = serviceRaceHistory;
            _mapperRaceHistory = mapperRaceHistory;
        }

        public Task<int> CreateAsync(RaceHistoryDTO entity)
        {
            var raceHistory = _mapperRaceHistory.MapperDTOtoEntity(entity);
            return _serviceRaceHistory.CreateAsync(raceHistory);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _serviceRaceHistory.DeleteAsync(id);
        }

        public IEnumerable<RaceHistoryDTO> GetAllAsync()
        {
            var raceHistory = _serviceRaceHistory.GetAllAsync();
            return _mapperRaceHistory.MapperListRaceHistoryDTO(raceHistory.Result);
        }

        public RaceHistoryDTO GetByIdAsync(int id)
        {
            var raceHistory = _serviceRaceHistory.GetByIdAsync(id);
            RaceHistoryDTO raceHistoryDTO = _mapperRaceHistory.MapperEntitytoDTO(raceHistory.Result);
            return raceHistoryDTO;
        }

        public IEnumerable<RaceHistoryDTO> ListDetails()
        {
            var raceHistory = _serviceRaceHistory.ListDetailsHistory().Result;
            return _mapperRaceHistory.MapperListRaceHistoryDTO(raceHistory);
        }

        public RaceHistoryDTO ListDetails(int id)
        {
            var raceHistory = _serviceRaceHistory.ListDetailsHistoryById(id).Result;
            return _mapperRaceHistory.MapperEntitytoDTO(raceHistory);
        }

        public Task<int> UpdateAsync(RaceHistoryDTO entity)
        {
            var raceHistory = _mapperRaceHistory.MapperDTOtoEntity(entity);
            return _serviceRaceHistory.UpdateAsync(raceHistory);
        }
    }
}
