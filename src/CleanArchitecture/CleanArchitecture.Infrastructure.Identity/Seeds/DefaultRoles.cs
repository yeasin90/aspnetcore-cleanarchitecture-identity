using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new ApplicationRole(UserRoles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(UserRoles.Admin.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(UserRoles.Moderator.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(UserRoles.Basic.ToString()));
        }
    }
}
