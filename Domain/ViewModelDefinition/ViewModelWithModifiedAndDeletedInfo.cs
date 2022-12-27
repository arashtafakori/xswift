namespace CoreX.Structure
{
    public abstract class ViewModelWithModifiedAndDeletedInfo : IViewModel
    {
        public bool Deleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
