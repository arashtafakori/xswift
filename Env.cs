namespace CoreX.Structure
{
    public static class Env
    {
        private static EnvState? _state = null;
        public static EnvState State
        {
            get
            {
                if(_state == null)
                {
                    Enum.TryParse(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), out EnvState state);
                    _state = state;
                }

                return (EnvState)_state!;
            }
        }
    }
    public enum EnvState
    {
        Production,
        Development,
        Staging,
    }
}
