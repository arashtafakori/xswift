using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWithTheSpecificationsAlreadyExistsException : InvariantException
    {
        public EntityWithTheSpecificationsAlreadyExistsException()
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound, Resource.Entiy))
        {
        }

        public EntityWithTheSpecificationsAlreadyExistsException(string entityName)
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWithTheSpecificationsAlreadyExists, entityName))
        {
        }
    }
}