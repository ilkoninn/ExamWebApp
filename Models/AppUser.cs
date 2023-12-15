using Microsoft.AspNetCore.Identity;

namespace ExamWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
