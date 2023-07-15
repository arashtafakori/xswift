using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CoreX.Base
{
    public class Error
    {
        public Error(
            string service,
            ErrorType errorType,
            List<Issue> issues)
        {
            Service = service;
            ErrorType = errorType;
            Issues = issues;
        }
        [DataMember(Order = 1)]
        public virtual string Service { get; set; }
        [DataMember(Order = 2)]
        public virtual string Type { get { return ErrorType.ToString(); } }
        [DataMember(Order = 3)]
        public virtual List<Issue> Issues { get; set; }
        [JsonIgnore]
        public virtual ErrorType ErrorType { get; set; }
    }
}
