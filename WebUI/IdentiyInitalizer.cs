﻿using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public static class IdentiyInitalizer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("yunus");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Yunus",
                    Surname="Sandıkçı",
                    UserName="yunus",
                    Email = "yunus@gmail.com"
                };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
