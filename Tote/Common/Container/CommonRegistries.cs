using Common.Logger;
using StructureMap.Configuration.DSL;

namespace Common.Container
{
    public class CommonRegistries:Registry
    {
        public CommonRegistries()
        {
            For<ILogger>().Use<Common.Logger.Logger>();
            
        }
    }
}
