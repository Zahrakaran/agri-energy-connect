using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect.Data;

namespace Agri_EnergyConnect.Controllers
{
    public class ContactController : Controller
    {
            private readonly ApplicationDbContext _context;

            public ContactController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Contact()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Contact(Message message)
            {
                if (!ModelState.IsValid)
                    return View(message);

                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Message sent successfully!";
                return RedirectToAction("Contact");
            }

        }
    }
    
