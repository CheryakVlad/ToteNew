
using StructureMap.Configuration.DSL;
using Business.Providers;



namespace Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            /*For<ICommandProvider>().Use<CommandProvider>();
            For<IMatchProvider>().Use<MatchProvider>();
            For<IRateProvider>().Use<RateProvider>();
            For<ITournamentProvider>().Use<TournamentProvider>();
            For<INavigationProvider>().Use<NavigationProvider>();*/
            For<IRateListProvider>().Use<RateListProvider>();
        }
    }
}
