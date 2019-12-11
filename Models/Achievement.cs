/**
 * Created By:     Visual Studio Community 2019
    Modified By:    Beverly Yee
    Date:           2019.12.09
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Models
{
    public class Achievement
    {
        public int AchievementID { get; set; }
        public int SolderID { get; set; }

        public string Description { get; set; }
        public string Battle { get; set; }
        public string Reward { get; set; }
    
        // navigation propery
        public Soldier Soldier { get; set; }
    }
}
