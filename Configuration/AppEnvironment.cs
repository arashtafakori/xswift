using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artaware.Infrastructure.CoreX
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
