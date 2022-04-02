using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }

        public virtual User Owner { get; set; }
        public virtual Car Car { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
