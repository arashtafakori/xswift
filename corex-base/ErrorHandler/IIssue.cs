using System.Runtime.Serialization;

namespace CoreX.Base
{
    public interface IIssue
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public string Description { get; set; }
    }
}
