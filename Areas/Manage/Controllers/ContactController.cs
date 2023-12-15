using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Areas.Manage.Controllers
{
    public class ContactController : Controller
    { 
        [Area("Manage")]
        public async Task<IActionResult> Table()
        {
            return View();
        }
    }
}
