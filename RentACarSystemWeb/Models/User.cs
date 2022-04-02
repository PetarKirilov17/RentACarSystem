using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserQueries = new List<Query>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(10)]
        public string EGN { get; set; }

        public virtual List<Query> UserQueries { get; set; }
    }
}
