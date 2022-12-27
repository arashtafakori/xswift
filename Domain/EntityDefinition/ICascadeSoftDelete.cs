namespace CoreX.Structure
{
    public interface ICascadeSoftDelete
    {
        public byte SoftDeleteLevel { get; set; }
        public DateTime? DeletationDate { get; set; }
    }
}
