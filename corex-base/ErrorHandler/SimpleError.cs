using System.Collections;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CoreX.Base
{
    public class SimpleError
    {
        internal SimpleError(
            string code,
            string description,
            ExceptionType? errorType = null,
            IDictionary? data = null)
        {
            Code = code;
            Description = description;
            ErrorType = errorType;
            Data = data;
        }
        [DataMember(Order = 1)]
        public virtual string Code { get; private set; }
        [DataMember(Order = 2)]
        public virtual string Type { get { return ErrorType.ToString()!; } }
        [DataMember(Order = 3)]
        public virtual string Description { get; set; }
        [DataMember(Order = 4)]
        public virtual IDictionary? Data { get; private set; }
        [JsonIgnore]
        public virtual ExceptionType? ErrorType { get; private set; }
    }
}
