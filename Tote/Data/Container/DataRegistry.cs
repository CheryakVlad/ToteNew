

using StructureMap.Configuration.DSL;
using Data.Services;
using Data.Business;
using Data.Clients;

namespace Data.Container
{
    public class DataRegistry:Registry
    {
        public DataRegistry()
        {
            For<IUserService>().Use<Data.Services.UserService>();
            For<IDataService>().Use<DataService>();
            For<IBetListClient>().Use<BetListClient>();
            For<IUserClient>().Use<UserClient>();            
            For<IConvert>().Use<Data.Business.Convert>();
        }
        
    }
}
