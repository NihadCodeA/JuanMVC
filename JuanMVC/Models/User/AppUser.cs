using Microsoft.AspNetCore.Identity;

namespace JuanMVC.Models.User
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
