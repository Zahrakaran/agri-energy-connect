using System.ComponentModel.DataAnnotations;

namespace Agri_EnergyConnect.Models
{
    public class Employee
    {
            public int Id { get; set; }

            [Required, StringLength(100)]
            public string FullName { get; set; }

            [Required, StringLength(100)]
            public string Position { get; set; }  // Example: "Product Manager"

            [Required, EmailAddress]
            public string Email { get; set; }  // This will act as the Username

            [Required, DataType(DataType.Password)]
            public string Password { get; set; }

            public string Role { get; set; } = "Employee";
        }
    }


