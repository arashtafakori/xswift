namespace XSwift.Base
{
    /// <summary>
    /// Represents the environment configuration and provides methods to ensure specific environment states.
    /// </summary>
    public class Environment
    {
        private EnvironmentState? _state = null;

        /// <summary>
        /// Gets the current environment state based on the "ASPNETCORE_ENVIRONMENT" environment variable.
        /// </summary>
        public EnvironmentState State
        {
            get
            {
                // If the state has not been determined yet, try to parse it from the environment variable.
                if (_state == null)
                {
                    Enum.TryParse(
                        System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), out EnvironmentState state);
                    _state = state;
                }

                return (EnvironmentState)_state!;
            }
        }

        /// <summary>
        /// Ensures that the environment state is set to Development.
        /// Throws an exception if the state is different.
        /// </summary>
        public void EnsureStateIsDevelopment()
        {
            if (State != EnvironmentState.Development)
                throw new Exception("The state of environment is not the development.");
        }

        /// <summary>
        /// Ensures that the environment state is set to Production.
        /// Throws an exception if the state is different.
        /// </summary>
        public void EnsureStateIsProduction()
        {
            if (State != EnvironmentState.Production)
                throw new Exception("The state of environment is not the production.");
        }

        /// <summary>
        /// Ensures that the environment state is set to Staging.
        /// Throws an exception if the state is different.
        /// </summary>
        public void EnsureStateIsStaging()
        {
            if (State != EnvironmentState.Staging)
                throw new Exception("The state of environment is not the staging.");
        }
    }

    /// <summary>
    /// Represents possible states of the service environment.
    /// </summary>
    public enum EnvironmentState
    {
        Production,
        Development,
        Staging,
    }
}
