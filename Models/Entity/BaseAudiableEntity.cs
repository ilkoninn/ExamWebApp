namespace ExamWebApp.Models.Entity
{
    public abstract class BaseAudiableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
