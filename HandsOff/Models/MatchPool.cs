using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class MatchPool
    {
        List<Team> Teams = new List<Team>();

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }
    }
}

