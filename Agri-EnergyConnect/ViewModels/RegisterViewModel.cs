using System.ComponentModel.DataAnnotations;

namespace Agri_EnergyConnect.ViewModels
{
        public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string FullName { get; set; }

            // Optional: based on role
            public string Location { get; set; } // for Farmer
            public string Position { get; set; } // for Employee

            [Required]
            public string Role { get; set; } // "Farmer" or "Employee"
        }
    }
