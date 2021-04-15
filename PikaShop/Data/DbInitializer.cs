using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PikaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles

            if (!roleManager.RoleExistsAsync("admin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (!roleManager.RoleExistsAsync("user").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0869295974",
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.Count(u => u.Email == defaultUser.Email) == 0)
            {
                IdentityResult result = await userManager.CreateAsync(defaultUser, "Admin2000@");
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(defaultUser, "admin");
                    await userManager.AddToRoleAsync(defaultUser, "user");
                }
            }

        }
    }
}
