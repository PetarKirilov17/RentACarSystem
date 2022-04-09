using RentACarSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.ViewModels.Queries
{
    public class QueryIndexViewModel
    {
        [Key]
        public int Id { get; set; }

        public string OwnerName { get; set; }
        public string CarName { get; set; }

        public DateTime StartDate { get; set; }
            
        public DateTime EndDate { get; set; }
    }
}
