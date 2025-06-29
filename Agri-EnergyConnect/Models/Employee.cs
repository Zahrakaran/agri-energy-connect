﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri_EnergyConnect.Models
{
    public class Employee

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }  // Example: "Product Manager"

        [Phone]
        public string ContactNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }  // This will act as the Username

        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }
        public AppUser IdentityUser { get; set; }
    

    }
}


