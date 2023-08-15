using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWasNotFoundIssue : LogicalIssue
    {
        public EntityWasNotFoundIssue()
            : this(Resource.General_Entiy)
        { }
        public EntityWasNotFoundIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_EntityWasNotFound, entityName);
        }
    }
}