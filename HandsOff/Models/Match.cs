using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    public class Match
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }

        private int MaxTurns = 10000;
        private int TurnCounter = 0;
        private Player SelectedPlayerTeam1;
        private Player SelectedPlayerTeam2;
        private int Team1Points = 0;
        private int Team2Points = 0;

        public Match(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;

            while (TurnCounter < MaxTurns)
            {
                TakeTurn();
                TurnCounter++;
            }
        }

        private void TakeTurn()
        {
            SelectedPlayerTeam1 = team1.Players[1];
            SelectedPlayerTeam2 = team2.Players[1];

            Debug.Write(SelectedPlayerTeam1.Defence);

            if (SelectedPlayerTeam1.Pace > SelectedPlayerTeam2.Pace)
            {
                Team1Points++;
            }
            else
            {
                Team2Points++;
            }

            if (SelectedPlayerTeam1.Shooting > SelectedPlayerTeam2.Shooting)
            {
                // increment something
            }
            else
            {

            }

            if (SelectedPlayerTeam1.Defence > SelectedPlayerTeam2.Defence)
            {
                // increment something
            }
            else
            {

            }
        }
    }
}