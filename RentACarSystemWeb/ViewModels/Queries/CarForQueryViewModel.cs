﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.ViewModels.Queries
{
    public class CarForQueryViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
