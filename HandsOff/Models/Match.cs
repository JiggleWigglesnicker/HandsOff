using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int HalfTimeHomeGoals { get; set; }
        public int HalfTimeAwayGoals { get; set; }
        public int Action { get; set; } // A game is based on actions instead of minutes, a game has x action.



        public void StartMatch()
        {

        }

        public void ScoreHome()
        {
            this.HomeGoals++;
        }

        public void ScoreAway()
        {
            this.AwayGoals++;
        }

        public void HalfTime()
        {
            this.HalfTimeHomeGoals = this.HomeGoals;
            this.HalfTimeAwayGoals = this.AwayGoals;
        }

    }
}
