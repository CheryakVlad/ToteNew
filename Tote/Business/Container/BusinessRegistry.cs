
using StructureMap.Configuration.DSL;
using Business.Providers;
using Business.Service;

namespace Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ICacheService>().Use<CacheService>();
            For<ITeamProvider>().Use<TeamProvider>();
            For<IMatchProvider>().Use<MatchProvider>();
            For<ITournamentProvider>().Use<TournamentProvider>();
            For<ILoginService>().Use<LoginService>();
            For<IUserProvider>().Use<UserProvider>();
            For<IBetListProvider>().Use<BetListProvider>();
        }
    }
}
