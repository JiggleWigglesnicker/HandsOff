using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class MatchPool
    {
        List<Match> Matches = new List<Match>();

        public void AddTeam(Match match)
        {
            Matches.Add(match);
        }
    }
}

