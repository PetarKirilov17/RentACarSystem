using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.Models
{
    public class Car
    {

        public Car()
        {
            //TODO
            CarQueries = new List<Query>();
        }

        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public virtual List<Query> CarQueries { get; set; }
    }
}
    