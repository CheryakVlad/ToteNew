
using StructureMap.Configuration.DSL;
using Business.Providers;
using Business.Service;

namespace Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            /*For<ICommandProvider>().Use<CommandProvider>();
            For<IMatchProvider>().Use<MatchProvider>();
            For<IRateProvider>().Use<RateProvider>();*/
            For<ILoginService>().Use<LoginService>();
            For<IUserProvider>().Use<UserProvider>();
            For<IBetListProvider>().Use<BetListProvider>();
        }
    }
}
