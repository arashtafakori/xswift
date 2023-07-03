using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CoreX.Base
{
    public class DevError : Error
    {
        public DevError(
            Error error,
            EnvironmentState environmentState,
            object? stackTrace = null)
            : base(error.Service, error.Type, error.Issues)
        {
            StackTrace = stackTrace;
            EnvironmentState = environmentState;
        }

        public DevError(
            string service,
            string type,
            List<Issue> issues,
            EnvironmentState environmentState,
            object? stackTrace = null)
            : base(service,type, issues)
        {
            StackTrace = stackTrace;
            EnvironmentState = environmentState;
        }
        [DataMember(Order = 1)]
        public override string Service => base.Service;
        [DataMember(Order = 2)]
        public override string Type => base.Type;
        [DataMember(Order = 3)]
        public string State { get { return EnvironmentState.ToString(); } }
        [DataMember(Order = 4)]
        public override List<Issue> Issues => base.Issues;
        [DataMember(Order = 5)]
        public object? StackTrace { get; set; }
        [JsonIgnore]
        public EnvironmentState EnvironmentState { get; set; }
    }
}
