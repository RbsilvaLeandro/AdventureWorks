using AdventureWorks.Application;
using AdventureWorks.Application.Intefraces;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Mapper;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Core.Services;
using AdventureWorks.Domain.Services;
using Autofac;

namespace AdventureWorks.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            builder.RegisterType<CompetitorApplication>().As<IApplicationCompetitor>();
            builder.RegisterType<RaceHistoryApplication>().As<IApplicationRaceHistory>();
            builder.RegisterType<RaceTrackApplication>().As<IApplicationRaceTrack>();

            builder.RegisterType<CompetitorService>().As<IServiceCompetitor>();
            builder.RegisterType<RaceHistoryService>().As<IServiceRaceHistory>();
            builder.RegisterType<RaceTrackService>().As<IServiceRaceTrack>();

            builder.RegisterType<CompetitorRepository>().As<IRepositoryCompetitors>();
            builder.RegisterType<RaceHistoryRepository>().As<IRepositoryRaceHistory>();
            builder.RegisterType<RaceTrackRepository>().As<IRepositoryRaceTrack>();

            builder.RegisterType<MapperCompetitor>().As<IMapperCompetitors>();
            builder.RegisterType<MapperRaceHistory>().As<IMapperRaceHistory>();
            builder.RegisterType<MapperRaceTrack>().As<IMapperRaceTrack>();
            #endregion
        }
    }
}
