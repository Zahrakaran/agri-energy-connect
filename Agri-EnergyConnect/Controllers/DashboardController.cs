﻿using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using Agri_EnergyConnect.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
public class DashboardController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _context;

    public DashboardController(UserManager<AppUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains("Admin"))
            return RedirectToAction("AdminDashboard");

        if (roles.Contains("Farmer"))
            return RedirectToAction("FarmerDashboard");

        if (roles.Contains("Employee"))
            return RedirectToAction("EmployeeDashboard");

        return RedirectToAction("SharedForum");
    }

    [Authorize(Roles = "Farmer")]
    public async Task<IActionResult> FarmerDashboard()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var farmer = _context.Farmers.FirstOrDefault(f => f.IdentityUserId == user.Id);
        if (farmer == null)
            return NotFound("Farmer profile not found.");

        var forumPosts = _context.ForumPosts.Where(fp => fp.AuthorId == user.Id).ToList();
        var products = _context.Products.Where(p => p.FarmerId == farmer.Id).ToList();

        var model = new DashboardViewModel
        {
            Farmer = farmer,
            ForumPosts = forumPosts,
            Products = products,
            Role = "Farmer"
        };

        return View("~/Views/FarmerDashboard/Index.cshtml", model);
    }

    [Authorize(Roles = "Farmer")]
    // Show form for adding a new product
    public async Task<IActionResult> AddProduct()
    {
        var user = await _userManager.GetUserAsync(User);
        var farmer = _context.Farmers.FirstOrDefault(f => f.IdentityUserId == user.Id);

        if (farmer == null)
            return NotFound("Farmer profile not found.");

        return View(new Product { FarmerId = farmer.Id }); // Pre-fill FarmerId
    }

    [Authorize(Roles = "Farmer")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(Product product)
    {
        var user = await _userManager.GetUserAsync(User);
        var farmer = _context.Farmers.FirstOrDefault(f => f.IdentityUserId == user.Id);

        if (farmer == null)
            return NotFound("Farmer profile not found.");

        if (ModelState.IsValid)
        {
            product.FarmerId = farmer.Id; // Ensure correct farmer
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(FarmerDashboard));
        }

        return View(product);
    }

    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> EmployeeDashboard()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var employee = _context.Employees.FirstOrDefault(e => e.IdentityUserId == userId);

        if (employee == null)
            return NotFound("Employee profile not found.");

        var forumPosts = _context.ForumPosts.ToList();

        var model = new DashboardViewModel
        {
            Employee = employee,
            ForumPosts = forumPosts,
            Role = "Employee"
        };

        return View("~/Views/EmployeeDashboard/Index.cshtml", model);
    }

    // Show form to add a new Farmer
    [Authorize(Roles = "Employee")]
    public IActionResult AddFarmer()
    {
        return View(new Farmer());
    }

    [Authorize(Roles = "Employee")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFarmer(Farmer farmer)
    {
        if (ModelState.IsValid)
        {
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeeDashboard));
        }

        return View(farmer);
    }


    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminDashboard()
    {
        var forumPosts = _context.ForumPosts.ToList();

        var model = new DashboardViewModel
        {
            ForumPosts = forumPosts,
            Role = "Admin"
        };

        return View("~/Views/AdminDashboard/Index.cshtml", model);
    }

    public IActionResult SharedForum()
    {
        var posts = _context.ForumPosts.ToList();
        return View(posts);
    }

    [HttpPost]
    public async Task<IActionResult> SharedForum(string content)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

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
