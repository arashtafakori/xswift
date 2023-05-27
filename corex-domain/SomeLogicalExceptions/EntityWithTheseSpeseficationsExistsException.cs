using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWithTheseSpeseficationsExistsException : LogicalException
    {
        public EntityWithTheseSpeseficationsExistsException()
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound_ValidationError, Resource.Entiy))
        {
        }

        public EntityWithTheseSpeseficationsExistsException(string entityName)
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound_ValidationError, entityName))
        {
        }
    }
}