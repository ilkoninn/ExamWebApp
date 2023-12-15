using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = registerVM.Name,
                    Surname = registerVM.Surname,
                    Email = registerVM.Email,
                    UserName = registerVM.Username,
                };
                
                var result = await _userManager.CreateAsync(appUser, registerVM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Login", "Home");

                }

            }
            
            return View();
        }
    }
}
