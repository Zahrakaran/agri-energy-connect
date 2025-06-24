using Agri_EnergyConnect.Data;
using Agri_EnergyConnect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class CollaborationController : Controller
{
    private readonly ApplicationDbContext _context;  // or your context name
    private readonly UserManager<AppUser> _userManager;

    public CollaborationController(ApplicationDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var posts = _context.ForumPosts
            .OrderByDescending(p => p.PostedAt)
            .ToList();

        return View(posts);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            ModelState.AddModelError("content", "Post content cannot be empty.");
            var postsWithErrors = _context.ForumPosts
                .OrderByDescending(p => p.PostedAt)
                .ToList();

            return View(postsWithErrors);
        }

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

        return RedirectToAction(nameof(Index));
    }
}
