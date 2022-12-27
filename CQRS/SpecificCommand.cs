namespace CoreX.Structure
{
    public abstract class SpecificCommand<IdType> : Command
    {
        public SpecificCommand(IdType id)
        {
            Id = id;
        }
        public IdType Id { get; private set; }
    }
}
