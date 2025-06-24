using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Identity;

namespace Agri_EnergyConnect.Helpers
{
    public static class PasswordHelper
    {
        public static void GenerateUserPasswordHash()
        {
            var user = new AppUser
            {
                Id = "880243aa-9d2a-4ec5-b50b-11c9805b76e5",
                UserName = "nomsa@agri.com",
                NormalizedUserName = "NOMSA@AGRI.COM",
                Email = "nomsa@agri.com",
                NormalizedEmail = "NOMSA@AGRI.COM",
                EmailConfirmed = true,
                PhoneNumber = "0712345678",
                PhoneNumberConfirmed = true,
                FullName = "Nomsa Dlamini",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, "Password123!");

            Console.WriteLine($"PasswordHash: {user.PasswordHash}");
            Console.WriteLine($"SecurityStamp: {user.SecurityStamp}");
        }
    }
}
