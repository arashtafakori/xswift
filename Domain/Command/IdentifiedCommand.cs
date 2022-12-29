namespace Artaware.Infrastructure.CoreX
{
    public abstract class IdentifiedCommand<IdType> : BaseCommand
    {
        public IdentifiedCommand(IdType id)
        {
            Id = id;
        }
        public IdType Id { get; private set; }
    }
}
