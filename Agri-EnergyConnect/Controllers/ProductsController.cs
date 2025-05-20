using Agri_EnergyConnect.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // For Include()
using System;
using System.Linq;

namespace Agri_EnergyConnect.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult FilterProducts(string category, DateTime? fromDate, DateTime? toDate)
        {
            var products = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category == category);

            if (fromDate.HasValue)
                products = products.Where(p => p.ProductionDate >= fromDate.Value);

            if (toDate.HasValue)
                products = products.Where(p => p.ProductionDate <= toDate.Value);

            return View(products.ToList());
        }
    }

}

