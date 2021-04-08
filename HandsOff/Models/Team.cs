using System.Collections.Generic;

namespace HandsOff.Models
{
    public class Team
    {
        public string TeamName { get; set; }
        public List<Player> Players = new List<Player>(); // Array of Player, should not exceed 11 players

        /// <summary>
        /// Adds a player to the Players list
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayerToTeam(Player player)
        {
            Players.Add(player);
        }
    }
}
