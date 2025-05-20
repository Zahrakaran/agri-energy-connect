using System.ComponentModel.DataAnnotations;
namespace Agri_EnergyConnect.Models
{

    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int Price { get; set; }

        // Foreign key
        public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }
    }



}
