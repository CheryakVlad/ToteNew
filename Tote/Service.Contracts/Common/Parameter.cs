using System.Data;

namespace Service.Contracts.Common
{
    public class Parameter
    {
        public DbType Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
