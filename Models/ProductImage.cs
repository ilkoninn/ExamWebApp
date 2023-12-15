using ExamWebApp.Models.Entity;

namespace ExamWebApp.Models
{
    public class ProductImage :BaseAudiableEntity
    {
        public string ImgUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
