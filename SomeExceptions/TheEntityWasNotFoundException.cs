using Artaware.Infrastructure.CoreX.Properties;
using System.Data;

namespace Artaware.Infrastructure.CoreX
{
    public class TheEntityWasNotFoundException : ValidatingException
    {
        public TheEntityWasNotFoundException() : base(string.Format(Resources.TheEntityWasNotFound))
        {
        }
    }
}