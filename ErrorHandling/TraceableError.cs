using System.Collections;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Artaware.Infrastructure.CoreX
{
    public class TraceableError : Error
    {
        public TraceableError(
            string code,
            string description,
            ExceptionType errorType,
            EnvironmentState environmentMode,
            IDictionary? data = null,
            object? stackTrace = null) :base(code, description, errorType, data)
        {
            ErrorId = Guid.NewGuid();
            StackTrace = stackTrace;
            EnvironmentMode = environmentMode;
        }
        [DataMember(Order = 1)]
        public override string Code => base.Code;
        [DataMember(Order = 2)]
        public override string Type => base.Type;
        [DataMember(Order = 3)]
        public override string Description => base.Description;
        [DataMember(Order = 4)]
        public override IDictionary? Data => base.Data;
        [JsonIgnore]
        public override ExceptionType ErrorType => base.ErrorType;
        [DataMember(Order = 5)]
        public string Mode { get { return EnvironmentMode.ToString(); } }

        [DataMember(Order = 6)]
        public Guid ErrorId { get; private set; }
        [DataMember(Order = 7)]
        public object? StackTrace { get; set; }
        [JsonIgnore]
        public EnvironmentState EnvironmentMode { get; set; }
    }
}
