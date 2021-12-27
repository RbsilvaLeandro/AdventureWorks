using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Core.Services;
using AdventureWorks.Domain.Entities;

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
    }
}
