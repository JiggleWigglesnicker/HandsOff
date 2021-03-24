using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    public class Team
    {
        public String TeamName { get; set; }
        public List<Player> Players = new List<Player>(); // Array of Player, should not exceed 10 players/

        /// <summary>
        /// Sets a "Random" team name.
        /// </summary>
        public void GetRandomTeamName()
        {
            string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "Fc MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "FcG", "C# Masters", "UWP 4 Life", "Fc Frenkie", "VV Baptist", "James Blunt's Boys", "Ltjes Rozenwater", "Fc Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood"};            
            Random random = new Random();
            string RandomTeamName = TeamNames[random.Next(0, TeamName.Length)];
            Console.WriteLine("Random team name = "+RandomTeamName + ".");
            this.TeamName = RandomTeamName;
        }

        public void addPlayerToTeam(Player player)
        {
            Players.Add(player);
        }

        /// <summary>
        /// Check if team has 10 players and a team name
        /// </summary>
        /// <returns></returns>
        public bool CheckIfTeamIsComplete()
        {
            if (this.Players.Count == 10)
            {
                if (this.TeamName != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
