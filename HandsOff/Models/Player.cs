using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class Player
    {
        public int Number { get; set; }

        public int Pace { get; set; } 
        public int Shooting { get; set; }
        public int Passing { get; set; }
        public int Dribble { get; set; }
        public int Defence { get; set; } 
        public int Intelligence { get; set; } // Intelligence improves other attributes
    }

}
