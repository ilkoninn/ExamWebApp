using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
