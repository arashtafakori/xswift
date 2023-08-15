using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class CommandRequestById<TEntity, IdType> :
        CommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public CommandRequestById(IdType id) {
            Id = id;
        }

        public IdType Id { get; private set; }
 
        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
