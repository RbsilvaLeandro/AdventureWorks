using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorks.Application.DTOs;
using AdventureWorks.Domain.Entities;

namespace AdventureWorks.Application.Interfaces
{
    public interface IMapperRaceHistory
    {
        RaceHistory MapperDTOtoEntity(RaceHistoryDTO raceHistory);
        RaceHistoryDTO MapperEntitytoDTO(Domain.DTO.RaceHistoryDTO raceHistory);
        IEnumerable<RaceHistoryDTO> MapperListRaceHistoryDTO(IEnumerable<RaceHistory> raceHistory);
        IEnumerable<RaceHistoryDTO> MapperListRaceHistoryDTO(IEnumerable<Domain.DTO.RaceHistoryDTO> raceHistory);
        RaceHistoryDTO MapperEntitytoDTO(RaceHistory raceHistory);
    }
}
