using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWasNotFound : LogicalIssue
    {
        public EntityWasNotFound()
            : this(Resource.General_Entiy)
        { }
        public EntityWasNotFound(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_EntityWasNotFound, entityName);
        }
    }
}