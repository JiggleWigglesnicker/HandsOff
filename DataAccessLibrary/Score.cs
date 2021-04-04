using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Score
    {
        public String TeamName1 { get; set; }
        public String TeamName2 { get; set; }
        public int TeamScore1 { get; set; }
        public int TeamScore2 { get; set; }

        public Score(String teamname1, String teamname2, int teamscore1, int teamscore2)
        {
            this.TeamName1 = teamname1;
            this.TeamName2 = teamname2;
            this.TeamScore1 = teamscore1;
            this.TeamScore2 = teamscore2;
        }
    }
}
