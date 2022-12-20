using CoreX.Structure.Properties;
using System.Data;

namespace CoreX.Structure
{
    public class EntityWasFoundException : DataException
    {
        public EntityWasFoundException() : base(string.Format(Resources.EntityWasFound))
        {
        }
    }
}