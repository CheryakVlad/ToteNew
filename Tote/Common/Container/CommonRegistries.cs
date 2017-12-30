using Common.Logger;
using StructureMap.Configuration.DSL;

namespace Common.Container
{
    public class CommonRegistries:Registry
    {
        public CommonRegistries()
        {
            For<ILogger>().Use<Common.Logger.Logger>();

            /*For<ILogger>()
            .AlwaysUnique()
            .TheDefault.Is.ConstructedBy(s =>
            {
                if (s.ParentType == null)
                    return new Common.Logger.Logger(s.BuildStack.Current.ConcreteType);

                return new Common.Logger.Logger(s.ParentType);
            });*/
            //For(typeof(ILogService<>)).Use(typeof(LogService<>));

            //For<ILogService<T>>().Use<LogService<T>>();
        }
    }
}
