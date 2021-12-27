using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Mapper
{
    public class MapperRaceHistory : IMapperRaceHistory
    {
        public RaceHistory MapperDTOtoEntity(RaceHistoryDTO raceHistoryDTO)
        {
            return new RaceHistory()
            {
                Id = raceHistoryDTO.Id,
                CompetitorId = raceHistoryDTO.CompetitorId,
                RaceTrackId = raceHistoryDTO.RaceTrackId,
                DateTrack = raceHistoryDTO.DateTrack,
                TimeSpent = raceHistoryDTO.TimeSpent,               
            };
        }

        public RaceHistoryDTO MapperEntitytoDTO(RaceHistory raceHistory)
        {
            return new RaceHistoryDTO()
            {
                Id = raceHistory.Id,
                CompetitorId = raceHistory.CompetitorId,
                RaceTrackId = raceHistory.RaceTrackId,
                DateTrack = raceHistory.DateTrack,
                TimeSpent = raceHistory.TimeSpent
            };
        }

        public RaceHistoryDTO MapperEntitytoDTO(Domain.DTO.RaceHistoryDTO raceHistory)
        {
            return new RaceHistoryDTO()
            {
                Id = raceHistory.Id,
                CompetitorId = raceHistory.CompetitorId,
                RaceTrackId = raceHistory.RaceTrackId,
                DateTrack = raceHistory.DateTrack,
                TimeSpent = raceHistory.TimeSpent, 
                CompetitorName = raceHistory.CompetitorName,
                TrackDescription = raceHistory.TrackDescription
            };
        }

        public IEnumerable<RaceHistoryDTO> MapperListRaceHistoryDTO(IEnumerable<RaceHistory> raceHistory)
        {
            return raceHistory.Select(c => new RaceHistoryDTO { Id = c.Id, CompetitorId = c.CompetitorId, RaceTrackId = c.RaceTrackId, DateTrack = c.DateTrack, TimeSpent = c.TimeSpent });
        }

        public IEnumerable<RaceHistoryDTO> MapperListRaceHistoryDTO(IEnumerable<Domain.DTO.RaceHistoryDTO> raceHistory)
        {
            var hist = raceHistory.Select(c => new RaceHistoryDTO
            {
                Id = c.Id,
                CompetitorId = c.CompetitorId,
                CompetitorName = c.CompetitorName,
                RaceTrackId = c.RaceTrackId,
                TrackDescription = c.TrackDescription,
                DateTrack = c.DateTrack,
                TimeSpent = c.TimeSpent
            });

            return hist;
        }
    }
}
