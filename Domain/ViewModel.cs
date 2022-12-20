namespace CoreX.Structure
{
    public abstract class AdvancedViewModel : IViewModel
    {
        public bool Deleted { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
