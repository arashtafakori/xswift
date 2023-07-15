using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWasNotFoundIssue : Issue
    {
        public EntityWasNotFoundIssue()
            : this(Resource.Entiy)
        { }
        public EntityWasNotFoundIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound, entityName);
        }
    }
}