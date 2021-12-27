using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Application
{
    public class CompetitorApplication : IApplicationCompetitor
    {
        private readonly IServiceCompetitor _serviceCompetitor;
        private readonly IMapperCompetitors _mapperCompetitor;

        public CompetitorApplication(IServiceCompetitor serviceCompetitor, IMapperCompetitors mapperCompetitor)
        {
            _serviceCompetitor = serviceCompetitor;
            _mapperCompetitor = mapperCompetitor;
        }

        public Task<int> CreateAsync(CompetitorDTO entity)
        {
            var competitor = _mapperCompetitor.MapperDTOtoEntity(entity);
            return _serviceCompetitor.CreateAsync(competitor);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _serviceCompetitor.DeleteAsync(id);
        }

        public IEnumerable<CompetitorDTO> GetAllAsync()
        {
            var competitor = _serviceCompetitor.GetAllAsync();
            return _mapperCompetitor.MapperListCompetitorsDTO(competitor.Result);
        }

        public CompetitorDTO GetByIdAsync(int id)
        {
            var competitor = _serviceCompetitor.GetByIdAsync(id);
            CompetitorDTO competitorDTO = _mapperCompetitor.MapperEntitytoDTO(competitor.Result);
            return competitorDTO;
        }

        public Task<int> UpdateAsync(CompetitorDTO entity)
        {
            var competitor = _mapperCompetitor.MapperDTOtoEntity(entity);
            return _serviceCompetitor.UpdateAsync(competitor);
        }

    }
}
