using AdventureWorks.Application.DTOs;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;

namespace AdventureWorks.Application.Interfaces
{
    public interface IMapperRaceTrack
    {
        RaceTrack MapperDTOtoEntity(RaceTrackDTO racTrack);
        IEnumerable<RaceTrackDTO> MapperListRaceTracksDTO(IEnumerable<RaceTrack> racTracks);

        RaceTrackDTO MapperEntitytoDTO(RaceTrack racTrack);
    }
}
