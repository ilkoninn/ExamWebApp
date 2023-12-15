namespace ExamWebApp.Areas.Manage.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<ProductImageVM>? ProductImages { get; set; }
    }
    public class ProductImageVM
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
    }
}
