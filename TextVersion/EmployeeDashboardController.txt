using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using Agri_EnergyConnect.ViewModels;

namespace Agri_EnergyConnect.Controllers
{
    [Authorize(Roles = "Employee")] // Only Employees can access this controller
    public class EmployeeDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = _context.Employees.FirstOrDefault(e => e.IdentityUserId == userId);
            var forumPosts = _context.ForumPosts.ToList();

            var vm = new DashboardViewModel
            {
                Employee = employee,
                ForumPosts = forumPosts,
                Role = "Employee"
            };

            return View(vm); // Looks for Views/EmployeeDashboard/Index.cshtml
        }
    }
}
