using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


public class DashboardController : Controller
{
    // Accessible only by authenticated users
    [Authorize]
    public IActionResult Index() => RedirectToAction("SharedForum");

    [Authorize(Roles = "Farmer")]
    public IActionResult FarmerDashboard()
    {
        // load farmer-specific data, e.g. their products
        return View();
    }

    [Authorize(Roles = "Employee")]
    public IActionResult EmployeeDashboard()
    {
        // load employee data, e.g. list of all farmers
        return View();
    }

    [Authorize]
    public IActionResult SharedForum()
    {
        var posts = _context.ForumPosts.ToList();
        return View(posts);
    }


    [Authorize]
    public IActionResult Marketplace()
    {
        // load products for browsing
        return View();
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> SharedForum(string content)
    {
        var user = await _userManager.GetUserAsync(User);
        var post = new ForumPost
        {
            AuthorId = user.Id,
            AuthorName = user.UserName,
            PostedAt = DateTime.UtcNow,
            Content = content
        };
        _context.ForumPosts.Add(post);
        await _context.SaveChangesAsync();
        return RedirectToAction("SharedForum");
    }
}
