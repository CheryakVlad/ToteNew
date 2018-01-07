

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
            For<ISportConvert>().Use<Data.Business.SportConvert>();
            For<ITeamConvert>().Use<Data.Business.TeamConvert>();
            For<ITournamentConvert>().Use<Data.Business.TournamentConvert>();
            For<ITournamentService>().Use<Data.Services.TournamentService>();
            For<IUserConvert>().Use<Data.Business.UserConvert>();
            For<ISportConvert>().Use<Data.Business.SportConvert>();
            For<ISportService>().Use<Data.Services.SportService>();
            For<ITeamService>().Use<Data.Services.TeamService>();
            For<ISportClient>().Use<SportClient>();
        }
        
    }
}
