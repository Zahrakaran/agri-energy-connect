using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;

public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;

    public FarmerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult AddFarmer()
    {
        return View(); // Looks for Views/Farmer/AddFarmer.cshtml
    }

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer)
    {
        if (ModelState.IsValid)
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();
            return RedirectToAction("Index", "EmployeeDashboard");
        }
        return View(farmer);
    }
}
