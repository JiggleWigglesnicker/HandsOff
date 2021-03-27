using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    public class MatchPool
    {
        public List<Match> Matches = new List<Match>();
        //List<Match> Matches { get => Matches; set => Matches = value; } <----- Werkt dit ook ipv de AddTeam() ???


        public MatchPool()
        {
           
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }
    }
}