using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Core.Services;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Services
{
    public class RaceTrackService : ServiceBase<RaceTrack>, IServiceRaceTrack
    {
        private readonly IRepositoryRaceTrack _repositoryRaceTrack;
        public RaceTrackService(IRepositoryRaceTrack repositoryRaceTrack)
            : base(repositoryRaceTrack)
        {
            _repositoryRaceTrack = repositoryRaceTrack;
        }

        //public Task<IEnumerable<RaceTrack>> GetAllUnusedTracksAsync()
        //{
        //    return _repositoryRaceTrack.GetAllUnusedTracksAsync();
        //}
    }
}
