namespace CoreX.Domain
{
    public abstract class DeletedQuery : Query
    {
        public bool EvenTheDeletedOnes() { return false; }
    }
}
