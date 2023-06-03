using CoreationsTask.Data.Static;
using CoreationsTask.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreationsTask.Data
{
    public class ApplicationInitializer
    {


        public static async Task SeedYourRolesAndUserAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //roles
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                      await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminEmail = "admin@coreations.com";

                var admin = await userManager.FindByEmailAsync(adminEmail);
                 
                if (admin == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin",
                        Email = adminEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdmin, "Admin@123");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }


                string userEmail = "user@coreations.com";

                var user = await userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        FullName = "User",
                        Email = userEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newUser, "User@123");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
}
