using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Mapper
{
    public class MapperRaceTrack : IMapperRaceTrack
    {       
        public RaceTrack MapperDTOtoEntity(RaceTrackDTO raceTrackDTO)
        {
            return new RaceTrack()
            {
                Id = raceTrackDTO.Id,
                Description = raceTrackDTO.Description
            };
        }
               
        public RaceTrackDTO MapperEntitytoDTO(RaceTrack raceTrack)
        {
            return new RaceTrackDTO()
            {
                Id = raceTrack.Id,
                Description = raceTrack.Description
            };
        }

        public IEnumerable<RaceTrackDTO> MapperListRaceTracksDTO(IEnumerable<RaceTrack> racTracks)
        {
            return racTracks.Select(c => new RaceTrackDTO { Id = c.Id, Description = c.Description, IsUsed = c.IsUsed  });
        }
    }
}
