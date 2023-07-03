using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWasNotFound : Issue
    {
        public EntityWasNotFound()
            : this(Resource.Entiy)
        { }
        public EntityWasNotFound(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound, entityName);
        }
    }
}