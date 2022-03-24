using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badges
    {
        public Badges() { }

        public Badges( List<string> doors)
        {
            Doors = doors;
           
        }

        public int BadgeID { get; set; }

        public List<string> Doors { get; set; }



    }
    
    
    
}