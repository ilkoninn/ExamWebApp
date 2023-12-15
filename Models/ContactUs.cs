using ExamWebApp.Models.Entity;

namespace ExamWebApp.Models
{
    public class ContactUs : BaseAudiableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
