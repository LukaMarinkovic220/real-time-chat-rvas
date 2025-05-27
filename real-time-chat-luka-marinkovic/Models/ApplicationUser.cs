using Microsoft.AspNetCore.Identity;

namespace real_time_chat_luka_marinkovic.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
