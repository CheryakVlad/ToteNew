using Data.Container;
using StructureMap.Configuration.DSL;
using Business.Container;
using Common.Container;

namespace Tote.Dependencies.Registries
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(BusinessRegistry).Assembly);
                scan.Assembly(typeof(CommonRegistries).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}