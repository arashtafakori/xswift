using CoreX.Domain;
using MediatR;

namespace EntityFrameworkCore.CoreX
{
    public abstract class DbRequestHandler
    {
        private readonly IDatabase _database;
        public DbRequestHandler(IDatabase database)
        {
            _database = database;
            Provide();
        }

        private void Provide()
        {
            if(CheckImplementation(this, typeof(IRequestHandler<,>), typeof(Query)))
                _database.AsNoTraking();
        }

        private static bool CheckImplementation(object source, Type interfaceGenericType, Type genericType)
        {
            var typeArgs = from iType in source.GetType().GetInterfaces()
                           where iType.IsGenericType
                             && iType.GetGenericTypeDefinition() == interfaceGenericType
                           select iType.GetGenericArguments()[0];

            return (from type in typeArgs
                    where (from iType in type.GetInterfaces()
                           where iType == genericType
                           select iType).Any()
                    select type).Any();
        }

    }
}
