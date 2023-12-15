using ExamWebApp.Models.Entity;

namespace ExamWebApp.Models
{
    public class Product : BaseAudiableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
