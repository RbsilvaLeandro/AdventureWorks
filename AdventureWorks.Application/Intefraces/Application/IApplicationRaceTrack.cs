using AdventureWorks.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Intefraces
{
    public interface IApplicationRaceTrack
    {
        IEnumerable<RaceTrackDTO> GetAllAsync();
        RaceTrackDTO GetByIdAsync(int id);
        Task<int> CreateAsync(RaceTrackDTO entity);
        Task<int> UpdateAsync(RaceTrackDTO entity);
        Task<int> DeleteAsync(int id);
    }
}
