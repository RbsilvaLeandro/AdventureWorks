using AdventureWorks.Application.DTOs;
using AdventureWorks.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Interfaces
{
    public interface IMapperCompetitors
    {
        Competitors MapperDTOtoEntity(CompetitorDTO competitors);
       
        CompetitorDTO MapperEntitytoDTO(Competitors competitors);
        IEnumerable<CompetitorDTO> MapperListCompetitorsDTO(IEnumerable<Competitors> competitor);
    }
}
