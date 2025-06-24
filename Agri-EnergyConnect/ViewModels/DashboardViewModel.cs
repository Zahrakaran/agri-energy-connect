using Agri_EnergyConnect.Models;

namespace Agri_EnergyConnect.ViewModels
{
    public class DashboardViewModel
    {
        public Farmer? Farmer { get; set; }
        public Employee? Employee { get; set; }
        public List<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
        public string Role { get; set; } = "";
        public List<Product> Products { get; set; } = new List<Product>();

    }
}