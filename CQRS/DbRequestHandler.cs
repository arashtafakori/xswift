using CoreX.Base;
using MediatR;

namespace CoreX.Structure
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
            if(ReflectionUtils.IsGenericArgumentsIsIplementedInterfaceOfIplementedInterfaceOf
                (this, typeof(IRequestHandler<,>), typeof(IQuery)))
                _database.AsNoTraking();
        }
    }
}
