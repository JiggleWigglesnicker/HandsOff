using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class Team
    {
        public String TeamName { get; set; }
        public Array Players { get; set; }

        public void getRandomTeamName()
        {
            string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "Fc MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "FcG", "C# Masters", "UWP 4 Life", "Fc Frenkie", "VV Baptist", "James Blunt's Boys", "Ltjes Rozenwater", "Fc Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood"};            
            Random random = new Random();
            string RandomTeamName = TeamNames[random.Next(0, TeamName.Length)];
            Console.WriteLine("Random team name = "+RandomTeamName + ".");
            this.TeamName = RandomTeamName;
        }


    }
}
