using MediatR;

namespace Artaco.Infrastructure.CoreX
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
            if(CheckImplementation(this, typeof(IRequestHandler<,>), typeof(BaseQuery)))
                _database.AsNoTraking();
        }

        public bool CheckImplementation(object source, Type interfaceGenericType, Type genericType)
        {
            var typeArgs = from iType in source.GetType().GetInterfaces()
                           where iType.IsGenericType
                             && iType.GetGenericTypeDefinition() == interfaceGenericType
                           select iType.GetGenericArguments()[0];

            return (from t in typeArgs
                    where ReflectionUtils.IsIplementedInterfaceOf(t, genericType)
                    select t).Any();
        }

    }
}
