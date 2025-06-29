﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Agri_EnergyConnect.Models
{

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Category { get; set; }    

        public string Description { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]  // Specify precision/scale for EF Core
        public decimal Price { get; set; }


        [ForeignKey(nameof(Farmer))]
        public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }
    }



}
