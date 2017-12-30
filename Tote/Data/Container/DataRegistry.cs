

using StructureMap.Configuration.DSL;
using Data.Services;
using Data.Business;
using Data.Clients;
using log4net;

namespace Data.Container
{
    public class DataRegistry:Registry
    {
        public DataRegistry()
        {
            
            For<ILog>().Use(y => LogManager.GetLogger(typeof(BetListClient)));
            For<ILog>().Use(y => LogManager.GetLogger(typeof(MatchClient)));
            For<ILog>().Use(y => LogManager.GetLogger(typeof(TournamentClient)));
            For<ILog>().Use(y => LogManager.GetLogger(typeof(UserClient)));
            For<ILog>().Use(y => LogManager.GetLogger(typeof(TeamClient)));
            
            For<IMatchService>().Use<MatchService>();
            For<IMatchClient>().Use<MatchClient>();
            For<IMatchConvert>().Use<MatchConvert>();
            For<ITeamClient>().Use<TeamClient>();
            For<ITournamentClient>().Use<TournamentClient>();
            For<IUserClient>().Use<UserClient>();
            For<IUserService>().Use<Data.Services.UserService>();
            For<IDataService>().Use<DataService>();
            For<IBetListClient>().Use<BetListClient>();
            For<IUserClient>().Use<UserClient>();            
            For<IConvert>().Use<Data.Business.Convert>();
        }
        
    }
}
