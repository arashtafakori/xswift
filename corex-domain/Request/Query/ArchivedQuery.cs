namespace CoreX.Domain
{
    public abstract class ArchivedQuery : Query
    {
        public bool EvenTheDeletedOnes() { return false; }
    }
}
