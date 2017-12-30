
using StructureMap.Configuration.DSL;
using Business.Providers;
using Business.Service;

namespace Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IUpdateBetListService>().Use<UpdateBetListService>();
            For<IUpdateMatchService>().Use<UpdateMatchService>();
            For<IUpdateSportService>().Use<UpdateSportService>();
            For<IUpdateTeamService>().Use<UpdateTeamService>();
            For<IUpdateTournamentService>().Use<UpdateTournamentService>();
            For<IUpdateUserService>().Use<UpdateUserService>();

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
