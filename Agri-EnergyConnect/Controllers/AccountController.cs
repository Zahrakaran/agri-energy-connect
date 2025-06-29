﻿using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using Agri_EnergyConnect.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agri_EnergyConnect.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Check if Email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Email already in use.");
                return View(model);
            }

            // Create AppUser
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var createResult = await _userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }

            // Assign Role
            var addRoleResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!addRoleResult.Succeeded)
            {
                foreach (var error in addRoleResult.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }

            // Create related profile based on Role
            if (model.Role == "Farmer")
            {
                // Validate Location and other required fields if needed
                if (string.IsNullOrWhiteSpace(model.Location))
                {
                    ModelState.AddModelError(nameof(model.Location), "Location is required for Farmers.");
                    await _userManager.DeleteAsync(user); // rollback user creation
                    return View(model);
                }

                var farmer = new Farmer
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Location = model.Location,
                    IdentityUserId = user.Id,
                    ContactNumber = model.ContactNumber
                };

                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();
            }
            else if (model.Role == "Employee")
            {
                var employee = new Employee
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Position = model.Position ?? "", // optional
                    IdentityUserId = user.Id,
                    ContactNumber = model.ContactNumber
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Unknown role
                ModelState.AddModelError("", "Invalid role selected.");
                await _userManager.DeleteAsync(user);
                return View(model);

            }

            // Automatically sign in user after registration
            await _signInManager.SignInAsync(user, isPersistent: false);

            TempData["SuccessMessage"] = "Registration successful! Welcome aboard.";


            return RedirectToAction("Index", "Home");

        }


        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
      
            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Farmer"))
                    return RedirectToAction("Index", "FarmerDashboard");

                if (roles.Contains("Employee"))
                    return RedirectToAction("Index", "EmployeeDashboard");

                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "AdminDashboard");


                else
                    return RedirectToAction("AccessDenied", "Account"); ;
                }

                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); // Just show a "You are not authorized" message.
        }


        // POST: /Account/Logout
        [HttpPost]

            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    
}
