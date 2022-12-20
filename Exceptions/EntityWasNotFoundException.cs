using CoreX.Structure.Properties;
using System.Data;

namespace CoreX.Structure
{
    public class EntityWasNotFoundException : DataException
    {
        public EntityWasNotFoundException() : base(string.Format(Resources.EntityWasNotFound))
        {
        }
    }
}