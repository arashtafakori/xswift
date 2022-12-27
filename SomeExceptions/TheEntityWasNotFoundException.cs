using Artaco.Infrastructure.CoreX.Properties;
using System.Data;

namespace Artaco.Infrastructure.CoreX
{
    public class TheEntityWasNotFoundException : ValidatingException
    {
        public TheEntityWasNotFoundException() : base(string.Format(Resources.TheEntityWasNotFound))
        {
        }
    }
}