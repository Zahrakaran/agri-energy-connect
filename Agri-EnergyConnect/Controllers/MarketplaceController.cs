using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class MarketplaceController : Controller
{
    private readonly ApplicationDbContext _context;

    public MarketplaceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        int nomsaFarmerId = 1; // Nomsa's FarmerId
        var products = await _context.Products
            .Where(p => p.FarmerId == nomsaFarmerId)
            .ToListAsync();

        return View(products);
    }
}
