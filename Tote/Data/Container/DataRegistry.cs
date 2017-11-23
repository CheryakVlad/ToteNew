

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
            //For<IUnitOfWork>().Use<UnitOfWork>();
            For<IDataService>().Use<DataService>();
            For<IRateListClient>().Use<RateListClient>();            
            For<IConvert>().Use<Data.Business.Convert>();
        }
        
    }
}
