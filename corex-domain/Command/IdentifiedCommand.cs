namespace CoreX.Domain
{
    public abstract class IdentifiedCommand<TCommand, IdType> : Command
    {
        public IdentifiedCommand(IdType id)
        {
            Id = id;
        }
        public IdType Id { get; private set; }
    }
}
