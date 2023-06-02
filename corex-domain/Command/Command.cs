namespace CoreX.Domain
{
    public abstract class Command
    {
        public ValidationContext Validation { get; private set; }

        public Command()
        {
            Validation = new();
        }
    }
}
