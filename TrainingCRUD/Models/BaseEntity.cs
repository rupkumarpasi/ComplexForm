namespace TrainingCRUD.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        //public Guid StudentId {  get; set; }
        public bool isDeleted { get; set; } = false;
        public string DeletedBy { get; set; } = string.Empty;

    }
}
