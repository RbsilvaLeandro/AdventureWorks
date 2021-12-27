using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Core.Services;
using AdventureWorks.Domain.Entities;

namespace AdventureWorks.Domain.Services
{
    public class CompetitorService : ServiceBase<Competitors> , IServiceCompetitor
    {
        private readonly IRepositoryCompetitors _repositoryCompetitor;
        public CompetitorService(IRepositoryCompetitors repositoryCompetitor)
            : base(repositoryCompetitor)    
        {
            _repositoryCompetitor = repositoryCompetitor;
        }
    }
}
