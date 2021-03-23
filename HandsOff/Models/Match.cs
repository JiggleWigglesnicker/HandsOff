﻿using System;
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
