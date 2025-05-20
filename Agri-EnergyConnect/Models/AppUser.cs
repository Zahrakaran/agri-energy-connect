using Microsoft.AspNetCore.Identity;

namespace Agri_EnergyConnect.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
