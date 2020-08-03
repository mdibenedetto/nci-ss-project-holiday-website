﻿
using System.Linq;
using dream_holiday.Models;
using Microsoft.AspNetCore.Identity;

namespace dream_holiday
{
    public static class StartupDbUsers
    {
        public static void SeedUsers(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            Data.ApplicationDbContext context)
        {

            CreateRoles(roleManager);
            CreateDefaultUsers(userManager, context);
        }

        // CREATE A ADMIN ROLE
        public static void CreateRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Roles.ADMIN).Result)
            {
                ApplicationRole role = new ApplicationRole { };
                role.Name = Roles.ADMIN;
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }           
        }

        // CREATE DEFAULT USER Admin
        public static void CreateDefaultUsers(
            UserManager<ApplicationUser> userManager, Data.ApplicationDbContext context)
        {
            const string DEFAULT_PASSWORD = "nci_admin_2020";
            const string USER_NAME = "admin";
            const string USER_EMAIL = "admin@dreamholiday.com";

            var foundUser = userManager.FindByNameAsync(USER_NAME);
            //test: userManager.DeleteAsync(foundUser.Result);
            //test foundUser = userManager.FindByNameAsync(USER_NAME);

            if (foundUser.Result == null)
            {
                // set default user attributes
                var user = new ApplicationUser();
                user.UserName = USER_NAME;
                user.Email = USER_EMAIL;
                // create new Admin user and assign ADMIN role to.
                var result = userManager.CreateAsync(user, DEFAULT_PASSWORD).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.ADMIN).Wait();
                } 
            }          
          
        }

    }
}