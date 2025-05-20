using System.ComponentModel.DataAnnotations;
namespace Agri_EnergyConnect.Models
{

    public class Farmer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(150)]
        public string Location { get; set; }

        [Required, Phone]
        public string ContactNumber { get; set; }
        public string Role { get; set; } = "Farmer";

        public ICollection<Product> Products { get; set; }
    }

}
