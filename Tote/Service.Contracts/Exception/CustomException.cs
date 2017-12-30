using System.Runtime.Serialization;

namespace Service.Contracts.Exception
{
    [DataContract]
    public class CustomException
    {
        [DataMember]
        public string Title;
        
    }
}
