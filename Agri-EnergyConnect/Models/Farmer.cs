﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Agri_EnergyConnect.Models
{

    public class Farmer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [ StringLength(150)]
        public string Location { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }
        public AppUser IdentityUser { get; set; }



        public ICollection<Product> Products { get; set; }

        public Farmer()
        {
            Products = new List<Product>();
        }
    }

}
