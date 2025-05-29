using Microsoft.AspNetCore.Identity;
using real_time_chat_luka_marinkovic.Models;

namespace real_time_chat_luka_marinkovic.Data
{
    public static class DbSeeder 
    {
        public static async Task SeedUsers(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<ApplicationUser>>();

            if (await userManager.FindByEmailAsync("test@test.com") == null)
            {
                var user1 = new ApplicationUser
                {
                    DisplayName = "test",
                    UserName = "test@test.com",
                    Email = "test@test.com",
                };
                await userManager.CreateAsync(user1, "Test1!");
            }

            if (await userManager.FindByEmailAsync("user@user.com") == null)
            {
                var user2 = new ApplicationUser
                {
                    DisplayName = "user",
                    UserName = "user@user.com",
                    Email = "user@user.com",
                };
                await userManager.CreateAsync(user2, "User1!");
            }

            if (await userManager.FindByEmailAsync("luka@luka.com") == null)
            {
                var user3 = new ApplicationUser
                {
                    DisplayName = "luka",
                    UserName = "luka@luka.com",
                    Email = "luka@luka.com",
                };
                await userManager.CreateAsync(user3, "Luka1!");
            }
        }
    }
}