using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agri_EnergyConnect.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            // Ensure database is created
            context.Database.Migrate();

            // Seed roles
            string[] roles = { "Farmer", "Employee", "Admin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Seed default Admin user
            var adminEmail = "admin@agri.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newUser = new AppUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FullName = "System Administrator"

                };

                var result = await userManager.CreateAsync(newUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, "Admin");
                }
            }




            // Seed Farmer + Products (your existing logic)
            if (!context.Farmers.Any())
            {
                var farmer1 = new Farmer
                {
                    FullName = "Thabo Mokoena",
                    Location = "Limpopo",
                    ContactNumber = "0821234567",
                    Products = new List<Product>
                    {
                        new Product { Name = "Maize", Category = "Grains", ProductionDate = DateTime.Now.AddDays(-10) },
                        new Product { Name = "Tomatoes", Category = "Vegetables", ProductionDate = DateTime.Now.AddDays(-5) }
                    }
                };

                var farmer2 = new Farmer
                {
                    FullName = "Nomsa Dlamini",
                    Location = "Eastern Cape",
                    ContactNumber = "0839876543",
                    Products = new List<Product>
                    {
                        new Product { Name = "Apples", Category = "Fruits", ProductionDate = DateTime.Now.AddDays(-15) }
                    }
                };

                context.Farmers.AddRange(farmer1, farmer2);
                context.SaveChanges();
            }
        }
    }
}

