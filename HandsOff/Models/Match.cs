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

        private int MaxTurns = 10000;                        // Maximum amount of turns
        private int TurnCounter = 0;                        // Keep track of the number of turns passed
        public String ProgressString { get; private set; } = "";

        public int Team1Score { get; private set; } = 0;    // De score van team 1, deze wordt uiteindelijk opgeslagen
        public int Team2Score { get; private set; } = 0;    // De score van team 2, deze wordt uiteindelijk opgeslagen

        private int BallPosition;                           // Position of the football. values 1-8
        private int BallOwner;                              // welk Team balbezit heeft (1 of 2)

        private Player SelectedPlayerTeam1;
        private Player SelectedPlayerTeam2;

        // placeholders for calculating the football game
        private double combinedAttackTeam1;
        private double combinedDefenseTeam1;
        private double combinedSpeedTeam1;
        private double combinedAttackTeam2;
        private double combinedDefenseTeam2;
        private double combinedSpeedTeam2;
        double TotalTeam1;
        double TotalTeam2;

        System.Random randomPlayerSelector = new System.Random();
        System.Random randomChangeGenerator = new System.Random();
        
        public Match(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        public void progressStringUpdate()
        {
            if (TurnCounter >= 200)
                ProgressString += "#+";
            if (TurnCounter < 200)
            {
                ProgressString += "#";
            }

        }

        public void StartSimulation()
        {
            Debug.WriteLine("Starting match!!!");

            // Start the match with Team 1 
            BallPosition = 4;
            BallOwner = 1;
            int i = 0;

            while (TurnCounter < MaxTurns)
            {
                i++;
                TakeTurn();
                if (i == 50 || TurnCounter >= 200)
                {
                    progressStringUpdate();
                    i = 0;
                }

                

                TurnCounter++;

                //Debug.WriteLine("Ball position: {0}", BallPosition);
                //Debug.WriteLine("Turn: {0}", TurnCounter);

                if ((TurnCounter + 1) > MaxTurns)
                {
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
                    if (AttemptAdvance(1, 1) == true)
                    {
                        Team1Score++;
                        BallOwner = 2;
                        BallPosition = 4;
                    }
                    else // failed! Team 2 gets the ball now
                    {
                        BallOwner = 2;
                        BallPosition = 5;
                    }
                }
                else if (BallPosition == 7) // Attempt to get through the defense players
                {
                    if (AttemptAdvance(3, 4) == true) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition++;
                    }
                    else // failed! Team 2 gets the ball now
                    {
                        BallOwner = 2;
                    }
                }
                else
                {
                    if (AttemptAdvance(3, 3) == true) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition++;
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
                    if (AttemptAdvance(1, 1) == true)
                    {
                        Team2Score++;
                        BallOwner = 1;
                        BallPosition = 4;
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                        BallPosition = 4;
                    }
                }
                else if (BallPosition == 1) // Attempt to get through the defense players
                {
                    if (AttemptAdvance(3, 4) == true) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition--;
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                    }
                }
                else
                {
                    if (AttemptAdvance(3, 3) == true) // in all other cases, the attackers are trying to advance through the midfielders
                    {
                        BallPosition--;
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                    }
                }
            }
        }

        private bool AttemptAdvance(int AmoundOfPlayersAttacking, int AmoundOfPlayersDefending)
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
                for (i = AmoundOfPlayersAttacking; i > 0; i--)
                {
                    SelectedPlayerTeam1 = team1.Players[randomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    combinedAttackTeam1 += SelectedPlayerTeam1.Shooting;
                    combinedSpeedTeam1 += SelectedPlayerTeam1.Pace;
                }

                // get numbers for the defending team (team 2)
                int u;
                for (u = AmoundOfPlayersDefending; u > 0; u--)
                {
                    switch (AmoundOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam2 = team2.Players[1]; // only one defender keeper is chosen
                            //combinedDefenseTeam2 = combinedDefenseTeam2 + 1;
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

                // calculate if attacking team will be succesfull
                double p;

                p = (randomChangeGenerator.NextDouble() + 1);
                TotalTeam1 = (((combinedAttackTeam1 + combinedSpeedTeam1) / 2) * p);
                
                p = (randomChangeGenerator.NextDouble() + 1);
                TotalTeam2 = (((combinedDefenseTeam2 + combinedSpeedTeam2) / 2) * p);

                if (TotalTeam1 > TotalTeam2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // get numbers for the attacking team (team 2)
                int i;
                for (i = AmoundOfPlayersAttacking; i > 0; i--)
                {
                    SelectedPlayerTeam2 = team2.Players[randomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    combinedAttackTeam2 += SelectedPlayerTeam2.Shooting;
                    combinedSpeedTeam2 += SelectedPlayerTeam2.Pace;
                }

                // get numbers for the defending team (team 1)
                int u;
                for (u = AmoundOfPlayersDefending; u > 0; u--)
                {
                    switch (AmoundOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam1 = team1.Players[1]; // only one defender. keeper is chosen
                            //combinedDefenseTeam2 = combinedDefenseTeam2 + 1;
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

                // calculate if attacking team will be succesfull
                double p;

                p = (randomChangeGenerator.NextDouble() + 1);
                TotalTeam2 = (((combinedAttackTeam1 + combinedSpeedTeam1) / 2) * p);

                p = (randomChangeGenerator.NextDouble() + 1);
                TotalTeam1 = (((combinedDefenseTeam2 + combinedSpeedTeam2) / 2) * p);

                if (TotalTeam2 > TotalTeam1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}