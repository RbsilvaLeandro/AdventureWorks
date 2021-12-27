using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application
{
    public class RaceTrackApplication : IApplicationRaceTrack
    {
        private readonly IServiceRaceTrack _serviceRaceTrack;
        private readonly IMapperRaceTrack _mapperRaceTrack;

        public RaceTrackApplication(IServiceRaceTrack serviceRaceTrack, IMapperRaceTrack mapperRaceTrack)
        {
            _serviceRaceTrack = serviceRaceTrack;
            _mapperRaceTrack = mapperRaceTrack;
        }

        public Task<int> CreateAsync(RaceTrackDTO entity)
        {
            var raceTrack = _mapperRaceTrack.MapperDTOtoEntity(entity);
            return _serviceRaceTrack.CreateAsync(raceTrack);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _serviceRaceTrack.DeleteAsync(id);
        }

        public IEnumerable<RaceTrackDTO> GetAllAsync()
        {
            var raceTrack = _serviceRaceTrack.GetAllAsync();
            return _mapperRaceTrack.MapperListRaceTracksDTO(raceTrack.Result);
        }

        public RaceTrackDTO GetByIdAsync(int id)
        {
            var raceTrack = _serviceRaceTrack.GetByIdAsync(id);
            RaceTrackDTO raceTrackDTO = _mapperRaceTrack.MapperEntitytoDTO(raceTrack.Result);
            return raceTrackDTO;
        }

        public Task<int> UpdateAsync(RaceTrackDTO entity)
        {
            var raceTrack = _mapperRaceTrack.MapperDTOtoEntity(entity);
            return _serviceRaceTrack.UpdateAsync(raceTrack);
        }
    }
}
