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
    public class Unit
    {
        public int UnitID { get; set; }

        public string Name { get; set; }
    
        public int Numbers { get; set; }

        public int? OfficerID { get; set; }
        [Display(Name = "Commanding Officer")]
        public Officer Admin { get; set; }
        public ICollection<Soldier> Soldiers { get; set; } 
    }
}
