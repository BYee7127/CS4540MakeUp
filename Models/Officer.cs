using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Models
{
    public class Officer
    {
        public int OfficerID { get; set; }
        public string UserID { get; set; }

        // Name
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Name")]
        public string FullName { get { return LastName + " " + FirstName; } }

        public string Email { get; set; }

        // Statistics
        [Display(Name = "Years of Service")]
        public int Years { get; set; }
        public string Status { get; set; }
        public int Rank { get; set; }
    }
}
