namespace XSwift.Base
{
    public class AppEnvironment
    {
        private EnvironmentState? _state = null;
        public EnvironmentState State
        {
            get
            {
                if (_state == null)
                {
                    Enum.TryParse(
                        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), out EnvironmentState state);
                    _state = state;
                }

                return (EnvironmentState)_state!;
            }
        }
    }

    public enum EnvironmentState
    {
        Production,
        Development,
        Staging,
    }
}
