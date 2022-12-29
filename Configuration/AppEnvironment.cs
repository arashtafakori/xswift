namespace Artaware.Infrastructure.CoreX
{
    public static class AppEnvironment
    {
        private static EnvironmentState? _state = null;
        public static EnvironmentState State
        {
            get
            {
                if(_state == null)
                {
                    Enum.TryParse(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), out EnvironmentState state);
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
