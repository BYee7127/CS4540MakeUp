/**
 * Created By:     Visual Studio Community 2019
    Modified By:    Beverly Yee
    Date:           2019.12.09
**/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Models
{
    public class Soldier
    {
        public int SoldierID { get; set; }

        // Name
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Name")]
        public string FullName { get { return LastName + " " + FirstName; } }

        // Statistics
        public string Status { get; set; }
        public int Age { get; set; }
        public string Birthplace { get; set; }

        // navigation properties
        public int UnitID { get; set; }     // foreign key constraint (?)
        public int? COID { get; set; }

        public Unit Unit { get; set; }
        public Officer CO { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
    }
}
