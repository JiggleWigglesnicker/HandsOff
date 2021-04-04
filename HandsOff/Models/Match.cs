using System.Diagnostics;
using DataAccessLibrary;

namespace HandsOff.Models
{
    public class Match
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }

        private static readonly int MaxTurns = 5000000;     // Maximum amount of turns
        public int TurnCounter { get; private set; } = 0;   // Keep track of the number of turns passed

        public int Team1Score { get; private set; }         // De score van team 1, deze wordt uiteindelijk opgeslagen
        public int Team2Score { get; private set; } = 0;    // De score van team 2, deze wordt uiteindelijk opgeslagen

        private int BallPosition;                           // Position of the football. values 1-8
        private int BallOwner;                              // welk Team balbezit heeft (1 of 2)
        private int randomLuck;                             // Generates a random number from 1-90, representing the luck 

        private Player SelectedPlayerTeam1;
        private Player SelectedPlayerTeam2;

        // placeholders for calculating the football game
        private double combinedAttackTeam1, combinedDefenseTeam1, combinedSpeedTeam1, combinedAttackTeam2, combinedDefenseTeam2, combinedSpeedTeam2, TotalTeam1, TotalTeam2;
        readonly System.Random randomPlayerSelector = new System.Random();
        readonly System.Random randomChangeGenerator = new System.Random();

        public Match(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        public void StartSimulation()
        {
            Debug.WriteLine("Starting match!!!");

            // Start the match with Team 1 
            BallPosition = 4;
            BallOwner = 1;

            while (TurnCounter < MaxTurns)
            {
                TakeTurn();
                TurnCounter++;

                if ((TurnCounter + 1) > MaxTurns)
                {
                    DataAccess.AddScores(team1.TeamName, team2.TeamName, Team1Score, Team2Score);
                    Debug.WriteLine("Done! final score: Team 1: {0} and Team 2: {1}", Team1Score, Team2Score);
                }
            }
        }

        private void TakeTurn()
        {
            if (BallOwner == 1) // team 1 owns the ball
            {
                // first check if a goal attempt is possible, if failed return the ball to the other team
                // Goal attempt is made by just one attacker
                // if goal is not possible, then team 1 trying to advance forwards
                if (BallPosition == 8) // Ball has reached the bottom of the field and a goal attempt can be made
                {
                    if (AttemptAdvance(1, 1) == 1)
                    {
                        Team1Score++;
                        BallOwner = 2;
                        BallPosition = 4;
                    }
                    else if (AttemptAdvance(1, 1) == 0)
                    {
                        // stalemate. nothing changes, team 1 gets to try another time to break the defense.
                    }
                    else // failed! Team 2 gets the ball now
                    {
                        BallOwner = 2;
                        BallPosition = 5;
                    }
                }
                else if (BallPosition == 7) // Attempt to get through the defense players
                {
                    if (AttemptAdvance(3, 4) == 1) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition++;
                    }
                    else if (AttemptAdvance(3, 4) == 0)
                    {
                        // stalemate. nothing changes, team 1 gets to try another time to break the defense.
                    }
                    else // failed! Team 2 gets the ball now
                    {
                        BallOwner = 2;
                    }
                }
                else
                {
                    if (AttemptAdvance(3, 3) == 1) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition++;
                    }
                    else if (AttemptAdvance(3, 3) == 0)
                    {
                        // stalemate. nothing changes, team 1 gets to try another time to break the defense.
                    }
                    else // failed! Team 2 gets the ball now
                    {
                        BallOwner = 2;
                    }
                }
            }
            else // team 2 owns the ball
            {
                // first check if a goal attempt is possible, if failed return the ball to the other team
                // Goal attempt is made by just one attacker
                // if goal is not possible, then team 1 trying to advance forwards
                if (BallPosition == 0) // Ball has reached the bottom of the field and a goal attempt can be made
                {
                    if (AttemptAdvance(1, 1) == 1)
                    {
                        Team2Score++;
                        BallOwner = 1;
                        BallPosition = 4;
                    }
                    else if (AttemptAdvance(1, 1) == 0)
                    {
                        // stalemate. nothing changes, team 2 gets to try another time to break the defense.
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                        BallPosition = 4;
                    }
                }
                else if (BallPosition == 1) // Attempt to get through the defense players
                {
                    if (AttemptAdvance(3, 4) == 1) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition--;
                    }
                    else if (AttemptAdvance(3, 4) == 0)
                    {
                        // stalemate. nothing changes, team 2 gets to try another time to break the defense.
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                    }
                }
                else
                {
                    if (AttemptAdvance(3, 3) == 1) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition--;
                    }
                    else if (AttemptAdvance(3, 3) == 0)
                    {
                        // stalemate. nothing changes, team 2 gets to try another time to break the defense.
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                    }
                }
            }
        }

        private int AttemptAdvance(int AmountOfPlayersAttacking, int AmountOfPlayersDefending)
        {
            // reset all values
            combinedAttackTeam1 = 0;
            combinedDefenseTeam1 = 0;
            combinedSpeedTeam1 = 0;
            combinedAttackTeam2 = 0;
            combinedDefenseTeam2 = 0;
            combinedSpeedTeam2 = 0;
            TotalTeam1 = 0;
            TotalTeam2 = 0;

            if (BallOwner == 1)
            {
                // get numbers for the attacking team (team 1)
                int i;
                for (i = AmountOfPlayersAttacking; i > 0; i--)
                {
                    SelectedPlayerTeam1 = team1.Players[randomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    combinedAttackTeam1 += SelectedPlayerTeam1.Shooting;
                    combinedSpeedTeam1 += SelectedPlayerTeam1.Pace;
                }

                // get numbers for the defending team (team 2)
                int u;
                for (u = AmountOfPlayersDefending; u > 0; u--)
                {
                    switch (AmountOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam2 = team2.Players[1]; // only one defender keeper is chosen
                            combinedDefenseTeam2 = combinedDefenseTeam2 + 150;
                            break;
                        case 2:
                        case 3:
                            SelectedPlayerTeam2 = team2.Players[randomPlayerSelector.Next(6, 9)]; // randomly choose between midfielders
                            break;
                        case 4:
                        default:
                            SelectedPlayerTeam2 = team2.Players[randomPlayerSelector.Next(2, 6)]; // randomly choose between defenders
                            break;
                    }

                    combinedDefenseTeam2 += SelectedPlayerTeam2.Defence;
                    combinedSpeedTeam2 += SelectedPlayerTeam2.Pace;
                }

                /** calculate if attacking team will be succesfull **/
                randomLuck = (randomChangeGenerator.Next(1, 91));
                TotalTeam1 = (randomLuck + (combinedAttackTeam1 / 30) + (combinedSpeedTeam1 / 30));

                randomLuck = (randomChangeGenerator.Next(1, 91));
                TotalTeam2 = (randomLuck + (combinedDefenseTeam2 / 30) + (combinedSpeedTeam2 / 30));

                //Debug.WriteLine("Total attacking team 1: {0} Total defending team 2: {1}", TotalTeam1, TotalTeam2);

                if ((TotalTeam1 / TotalTeam2) >= 3.9)
                {
                    return 1;
                }
                else if ((TotalTeam1 / TotalTeam2) >= 1.5 && (TotalTeam1 / TotalTeam2) < 3.9)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                // get numbers for the attacking team (team 2)
                int i;
                for (i = AmountOfPlayersAttacking; i > 0; i--)
                {
                    SelectedPlayerTeam2 = team2.Players[randomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    combinedAttackTeam2 += SelectedPlayerTeam2.Shooting;
                    combinedSpeedTeam2 += SelectedPlayerTeam2.Pace;
                }

                // get numbers for the defending team (team 1)
                int u;
                for (u = AmountOfPlayersDefending; u > 0; u--)
                {
                    switch (AmountOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam1 = team1.Players[1]; // only one defender. keeper is chosen
                            combinedDefenseTeam2 = combinedDefenseTeam2 + 150;
                            break;
                        case 2:
                        case 3:
                            SelectedPlayerTeam1 = team1.Players[randomPlayerSelector.Next(6, 9)]; // randomly choose between midfielders
                            break;
                        case 4:
                        default:
                            SelectedPlayerTeam1 = team1.Players[randomPlayerSelector.Next(2, 6)]; // randomly choose between defenders
                            break;
                    }

                    combinedDefenseTeam1 += SelectedPlayerTeam1.Defence;
                    combinedSpeedTeam1 += SelectedPlayerTeam1.Pace;
                }

                /** calculate if attacking team will be succesfull */
                randomLuck = (randomChangeGenerator.Next(1, 91));
                TotalTeam2 = (randomLuck + (combinedAttackTeam2 / 30) + (combinedSpeedTeam2 / 30));

                randomLuck = (randomChangeGenerator.Next(1, 91));
                TotalTeam1 = (randomLuck + (combinedDefenseTeam1 / 30) + (combinedSpeedTeam1 / 30));

                //Debug.WriteLine("Total attacking team 2: {0} Total defending team 1: {1}", TotalTeam2, TotalTeam1);

                if ((TotalTeam2 / TotalTeam1) >= 3.9)
                {
                    return 1;
                }
                else if ((TotalTeam2 / TotalTeam1) >= 1.5 && (TotalTeam2 / TotalTeam1) < 3.9)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}