namespace Artaware.Infrastructure.CoreX
{
    public abstract class DeletedQuery : BaseQuery
    {
        public bool EvenTheDeletedOnes() { return false; }
    }
}
