using System;
using System.Collections.Generic;

namespace HandsOff.Models
{
    public class Team
    {
        public String TeamName { get; set; }
        public List<Player> Players = new List<Player>(); // Array of Player, should not exceed 10 players/

        private readonly Random random = new Random();

        public void AddPlayerToTeam(Player player)
        {
            Players.Add(player);
        }

        public String getName()
        {
            return TeamName;
        }
    }
}
