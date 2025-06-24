using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect.ViewModels;
using Agri_EnergyConnect.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace Agri_EnergyConnect.Controllers
{
    [Authorize(Roles = "Farmer")] // restricts access to Farmers only
    public class FarmerDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public FarmerDashboardController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var userId = user.Id;

            var farmer = _context.Farmers.FirstOrDefault(f => f.IdentityUserId == userId);
            if (farmer == null)
                return RedirectToAction("AccessDenied", "Account");

            var employee = _context.Employees.FirstOrDefault(e => e.IdentityUserId == userId);
            var forumPosts = _context.ForumPosts.ToList();

            var role = farmer != null ? "Farmer" : employee != null ? "Employee" : "Unknown";

            var vm = new DashboardViewModel
            {
                Farmer = farmer,
                Employee = employee,
                ForumPosts = forumPosts,
                Role = role
            };

            return View(vm); // Looks for Views/FarmerDashboard/Index.cshtml
        }
    }
}
