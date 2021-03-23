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
        public int turns { get; set; } // A game is based on turns instead of minutes, a game has x turns. This is a set value.
        public int turnCounter { get; set; } // Keeps track of the amount of turns that has passed.



        public void StartMatch()
        {
            GiveBallToTeam(HomeTeam);
        }

        public void StartSecondHalf()
        {
            GiveBallToTeam(AwayTeam);
        }

        /// <summary>
        /// give to a midfielder of the team, if there is no midfielder in the team then give the ball to a random player of the team.
        /// </summary>
        /// <param name="team"></param>
        public void GiveBallToTeam(Team team)
        {
            Team t = team;
            Random random = new Random();
            int playerNumber = random.Next(0, t.Players.Length);


        }

        public void ScoreHome()
        {
            this.HomeGoals++;
            GiveBallToTeam(AwayTeam);
        }

        public void ScoreAway()
        {
            this.AwayGoals++;
            GiveBallToTeam(HomeTeam);
        }

        public void HalfTime()
        {
            this.HalfTimeHomeGoals = this.HomeGoals;
            this.HalfTimeAwayGoals = this.AwayGoals;
        }
    }
}
