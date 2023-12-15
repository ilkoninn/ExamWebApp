namespace ExamWebApp.Areas.Manage.ViewModels
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
