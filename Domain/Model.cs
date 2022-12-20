namespace CoreX.Structure
{
    public abstract class Model
    {
        public virtual void Creation() { throw new NotImplementedException(); }
        public virtual void Updation() { throw new NotImplementedException(); }
        public virtual void Deletion() { throw new NotImplementedException(); }
        public virtual void UnDeletion() { throw new NotImplementedException(); }
        public virtual void Validate() { throw new NotImplementedException(); }
    }
}
