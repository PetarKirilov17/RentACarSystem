using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.ViewModels.Cars
{
    public class EditViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Seats { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
    }
}
