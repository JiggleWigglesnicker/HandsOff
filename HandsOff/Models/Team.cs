using System;
using System.Collections.Generic;

namespace HandsOff.Models
{
    public class Team
    {
        public String TeamName { get; set; }
        public List<Player> Players = new List<Player>(); // Array of Player, should not exceed 11 players/

        public void AddPlayerToTeam(Player player)
        {
            Players.Add(player);
        }

        public String GetName()
        {
            return TeamName;
        }
    }
}
