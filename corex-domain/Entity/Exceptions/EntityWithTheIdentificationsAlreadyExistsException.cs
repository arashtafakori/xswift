using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class EntityWithTheIdentificationsAlreadyExistsException : InvariantException
    {
        public EntityWithTheIdentificationsAlreadyExistsException()
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWasNotFound, Resource.Entiy))
        {
        }

        public EntityWithTheIdentificationsAlreadyExistsException(string entityName)
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.EntityWithTheIdentificationsAlreadyExists, entityName))
        {
        }
    }
}