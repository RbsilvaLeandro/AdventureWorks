using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Mapper
{
    public class MapperCompetitor : IMapperCompetitors
    {
        public Competitors MapperDTOtoEntity(CompetitorDTO competitorDTO)
        {
            return new Competitors() 
            { 
                Id = competitorDTO.Id,
                Name = competitorDTO.Name,
                Gender = competitorDTO.Gender,
                BodyTemperature = competitorDTO.BodyTemperature,
                Weight = competitorDTO.Weight,
                Height = competitorDTO.Height
            };
        }

        public CompetitorDTO MapperEntitytoDTO(Competitors competitors)
        {
            return new CompetitorDTO()
            {
                Id = competitors.Id,
                Name = competitors.Name,
                Gender = competitors.Gender,
                BodyTemperature = competitors.BodyTemperature,
                Weight = competitors.Weight,
                Height = competitors.Height
            };

        }

        public IEnumerable<CompetitorDTO> MapperListCompetitorsDTO(IEnumerable<Competitors> competitor)
        {
            return competitor.Select(c => new CompetitorDTO { Id = c.Id, Name = c.Name, Gender = c.Gender, BodyTemperature = c.BodyTemperature, Weight = c.Weight, Height = c.Height, IsRunner = c.IsRunner, AverageRace = c.AverageRace });
        }
    }
}
