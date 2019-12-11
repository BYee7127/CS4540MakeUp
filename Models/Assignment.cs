using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public int OfficerID { get; set; }
        public int SoldierID { get; set; }
        public Officer Officer { get; set; }
        public Soldier Soldier { get; set; }
    }
}
