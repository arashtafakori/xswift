using Artaco.Infrastructure.CoreX.Structure.Properties;
using System.Data;

namespace CoreX.Structure
{
    public class TheEntityWasNotFoundException : DataException
    {
        public TheEntityWasNotFoundException() : base(string.Format(Resources.TheEntityWasNotFound))
        {
        }
    }
}