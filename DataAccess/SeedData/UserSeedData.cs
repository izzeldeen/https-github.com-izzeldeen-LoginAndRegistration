using Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public class UserSeedData
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new User
                {
                    Name = "Admin",
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    Department = new Department
                    {
                        Name = "Hyman Resourses"
                    }
                };

                await userManager.CreateAsync(user, "Admin@123");
            }
        }
    }
}
