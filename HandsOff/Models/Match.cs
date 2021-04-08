using DataAccessLibrary;
using System.Diagnostics;

namespace HandsOff.Models
{
    public class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        private static readonly uint MaxTurns = 3500000;        // Maximum amount of turns
        public uint TurnCounter { get; private set; }           // Keep track of the number of turns passed

        public ushort Team1Score { get; private set; }          // Total score of team 1, this gets stored when the match is finished
        public ushort Team2Score { get; private set; }          // Total score of team 2, this gets stored when the match is finished

        private short BallPosition;                               // Position of the football. values 1-8
        private byte BallOwner;                                 // Keeps track of which team owns the ball, values 1-2
        private int RandomLuck;                                 // Generates a random number rangin from 1-90, representing the random chance

        private Player SelectedPlayerTeam1;
        private Player SelectedPlayerTeam2;

        // placeholders for calculating the football game
        private double CombinedAttackTeam1, CombinedDefenseTeam1, CombinedSpeedTeam1, CombinedAttackTeam2, CombinedDefenseTeam2, CombinedSpeedTeam2, TotalTeam1, TotalTeam2;
        private byte AttackerAmountCounter, DefenderAmountCounter;

        // Random number generators to simulate the game
        private readonly System.Random RandomPlayerSelector = new System.Random();
        private readonly System.Random RandomChanceGenerator = new System.Random();

        public Match(Team Team1, Team Team2)
        {
            this.Team1 = Team1;
            this.Team2 = Team2;
        }

        /// <summary>
        /// This method starts the simulation and contains the loop where it is executed from.
        /// </summary>
        public void StartSimulation()
        {
            Debug.WriteLine("Starting match!!!");

            // Start the match with Team 1 
            BallPosition = 4;
            BallOwner = 1;
            TurnCounter = 1;

            while (TurnCounter < MaxTurns)
            {
                if (TurnCounter == 1750000)
                {
                    BallOwner = 2;
                }

                TakeTurn();
                TurnCounter++;

                if ((TurnCounter + 1) > MaxTurns)
                {
                    if (Team1Score == Team2Score)
                    {
                        penalty();
                    }
                    DataAccess.AddScores(Team1.TeamName, Team2.TeamName, Team1Score, Team2Score);
                    Debug.WriteLine("Done! final score: Team 1: {0} and Team 2: {1}", Team1Score, Team2Score);
                }
            }
        }
        
        /// <summary>
        /// Calculates every turn. Decides what happens to BallPosition and Ballowner 
        /// based on the output of the method AttemptAdvance().
        /// </summary>
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
                        BallPosition--; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
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
                        BallPosition--; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
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
                        BallPosition--; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
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
                        BallPosition++; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
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
                        BallPosition++; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
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
                        BallPosition++; // stalemate. Ball position goes back one but team 2 gets to try another time to break the defense.
                    }
                    else // failed! Team 1 gets the ball now
                    {
                        BallOwner = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Calculates each turn. The only parameters are the amount of players attacking 
        /// and defending. From these amounts, and the ballowner, can be deduced in what state 
        /// For example, with ballowner being 1 and with 1 player attacking and definding, then 
        /// Team 1 has to be making an attempt to score.
        /// </summary>
        /// <param name="AmountOfPlayersAttacking"></param>
        /// <param name="AmountOfPlayersDefending"></param>
        /// <returns></returns>
        private int AttemptAdvance(byte AmountOfPlayersAttacking, byte AmountOfPlayersDefending)
        {
            // reset all values
            CombinedAttackTeam1 = 0;
            CombinedDefenseTeam1 = 0;
            CombinedSpeedTeam1 = 0;
            CombinedAttackTeam2 = 0;
            CombinedDefenseTeam2 = 0;
            CombinedSpeedTeam2 = 0;
            TotalTeam1 = 0;
            TotalTeam2 = 0;

            if (BallOwner == 1)
            {
                // get numbers for the attacking team (team 1)
                AttackerAmountCounter = 0; // reset this value every time a calculation is made
                for (AttackerAmountCounter = AmountOfPlayersAttacking; AttackerAmountCounter > 0; AttackerAmountCounter--)
                {
                    SelectedPlayerTeam1 = Team1.Players[RandomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    CombinedAttackTeam1 += SelectedPlayerTeam1.Shooting;
                    CombinedSpeedTeam1 += SelectedPlayerTeam1.Pace;
                }

                // get numbers for the defending team (team 2)
                DefenderAmountCounter = 0; // reset this value every time a calculation is made
                for (DefenderAmountCounter = AmountOfPlayersDefending; DefenderAmountCounter > 0; DefenderAmountCounter--)
                {
                    switch (AmountOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam2 = Team2.Players[1]; // only one defender, therefore the keeper is chosen
                            CombinedDefenseTeam2 += 150;
                            break;
                        case 2:
                        case 3:
                            SelectedPlayerTeam2 = Team2.Players[RandomPlayerSelector.Next(6, 9)]; // randomly choose between midfielders
                            break;
                        case 4:
                        default:
                            SelectedPlayerTeam2 = Team2.Players[RandomPlayerSelector.Next(2, 6)]; // randomly choose between defenders
                            break;
                    }

                    CombinedDefenseTeam2 += SelectedPlayerTeam2.Defence;
                    CombinedSpeedTeam2 += SelectedPlayerTeam2.Pace;
                }

                /** calculate if attacking team will be succesfull **/
                RandomLuck = (RandomChanceGenerator.Next(1, 91));
                TotalTeam1 = (RandomLuck + (CombinedAttackTeam1 / 30) + (CombinedSpeedTeam1 / 30));

                RandomLuck = (RandomChanceGenerator.Next(1, 91));
                TotalTeam2 = (RandomLuck + (CombinedDefenseTeam2 / 30) + (CombinedSpeedTeam2 / 30));

                if ((TotalTeam1 / TotalTeam2) >= 3.4)
                {
                    return 1;
                }
                else if ((TotalTeam1 / TotalTeam2) >= 1.5 && (TotalTeam1 / TotalTeam2) < 3.4)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                // get numbers for the attacking team (team 2)
                AttackerAmountCounter = 0; // reset this value every time a calculation is made
                for (AttackerAmountCounter = AmountOfPlayersAttacking; AttackerAmountCounter > 0; AttackerAmountCounter--)
                {
                    SelectedPlayerTeam2 = Team2.Players[RandomPlayerSelector.Next(9, 11)]; // randomly choose between attackers

                    CombinedAttackTeam2 += SelectedPlayerTeam2.Shooting;
                    CombinedSpeedTeam2 += SelectedPlayerTeam2.Pace;
                }

                // get numbers for the defending team (team 1)
                DefenderAmountCounter = 0; // reset this value every time a calculation is made
                for (DefenderAmountCounter = AmountOfPlayersDefending; DefenderAmountCounter > 0; DefenderAmountCounter--)
                {
                    switch (AmountOfPlayersDefending)
                    {
                        case 1:
                            SelectedPlayerTeam1 = Team1.Players[1]; // only one defender, therefore the keeper is chosen
                            CombinedDefenseTeam2 += 150;
                            break;
                        case 2:
                        case 3:
                            SelectedPlayerTeam1 = Team1.Players[RandomPlayerSelector.Next(6, 9)]; // randomly choose between midfielders
                            break;
                        case 4:
                        default:
                            SelectedPlayerTeam1 = Team1.Players[RandomPlayerSelector.Next(2, 6)]; // randomly choose between defenders
                            break;
                    }

                    CombinedDefenseTeam1 += SelectedPlayerTeam1.Defence;
                    CombinedSpeedTeam1 += SelectedPlayerTeam1.Pace;
                }

                /** calculate if attacking team will be succesfull */
                RandomLuck = (RandomChanceGenerator.Next(1, 91));
                TotalTeam2 = (RandomLuck + (CombinedAttackTeam2 / 30) + (CombinedSpeedTeam2 / 30));

                RandomLuck = (RandomChanceGenerator.Next(1, 91));
                TotalTeam1 = (RandomLuck + (CombinedDefenseTeam1 / 30) + (CombinedSpeedTeam1 / 30));

                if ((TotalTeam2 / TotalTeam1) >= 3.8)
                {
                    return 1;
                }
                else if ((TotalTeam2 / TotalTeam1) >= 1.0 && (TotalTeam2 / TotalTeam1) < 3.8)
                {
                    return 0;
                }
                return -1;
            }
        }

        /// <summary>
        /// This method is only called when the endscore is equal. 
        /// This prevents a stalemate and from the score being 0 - 0.
        /// </summary>
        private void penalty()
        {
            while (Team1Score == Team2Score)
            {
                if (AttemptAdvance(1, 1) == 1)
                {
                    if (BallOwner == 1)
                    {
                        Team1Score++;
                    }
                    else
                    {
                        Team2Score++;
                    }
                }

                if (BallOwner == 1)
                {
                    BallOwner = 2;
                }
                else if (BallOwner == 2)
                {
                    BallOwner = 1;
                }
            }
        }
    }
}