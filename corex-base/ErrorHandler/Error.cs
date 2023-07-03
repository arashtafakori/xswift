using System.Runtime.Serialization;

namespace CoreX.Base
{
    public class Error
    {
        public Error(
            string service,
            string type,
            List<Issue> issues)
        {
            Service = service;
            Type = type;
            Issues = issues;
        }
        [DataMember(Order = 1)]
        public virtual string Service { get; set; }
        [DataMember(Order = 2)]
        public virtual string Type { get; set; }
        [DataMember(Order = 3)]
        public virtual List<Issue> Issues { get; set; }
    }
}
