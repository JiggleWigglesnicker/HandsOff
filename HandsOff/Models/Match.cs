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
        private int Team1Points = 0;            // Score van Team 1
        private int Team2Points = 0;            // Score van Team 2
        private int IsScoredValue = 100;        // Als de punten van een team hoger komt dan deze waarde, is er gescoord door het betreffende team
        private int Team1Score = 0;             // De score van team 1, deze wordt uiteindelijk opgeslagen
        private int Team2Score = 0;             // De score van team 2, deze wordt uiteindelijk opgeslagen


        public Match(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;

            while (TurnCounter < MaxTurns)
            {
                TakeTurn();
                CheckIfScored();

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
                Team1Points++;
            }
            else
            {
                Team2Points++;
            }

            if (SelectedPlayerTeam1.Defence > SelectedPlayerTeam2.Defence)
            {
                Team1Points++;
            }
            else
            {
                Team2Points++;
            }
        }

        private void CheckIfScored()
        {
            if(Team1Points > IsScoredValue)
            {
                Team1Score++;

                Team1Points = 0;
                Team2Points = 0;
            }

            if (Team2Points > IsScoredValue)
            {
                Team2Score++;

                Team1Points = 0;
                Team2Points = 0;
            }
        }
    }
}