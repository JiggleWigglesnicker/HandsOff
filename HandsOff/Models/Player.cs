using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    public class Player
    {
        private const    int         BaseStat    = 55;
        private readonly Random     random      = new Random();


        public int      Number          { get; set; }
        public string   Position        { get; set; } // this refers to the role of the player; players 1-2-3-4 defenders, 5, 6, 7, are midfielders, and 8, 9, 10 are attackers
        public bool     HasBall         { get; set; }

        /// <summary>
        /// Player Skills are based on a scale of 1 - 99
        /// </summary>
        public int      Pace            { get; set; }       = BaseStat;
        public int      Shooting        { get; set; }       = BaseStat;
        public int      Passing         { get; set; }       = BaseStat;
        public int      Dribble         { get; set; }       = BaseStat;
        public int      Defence         { get; set; }       = BaseStat;
        public int      Intelligence    { get; set; }       = BaseStat; // Intelligence improves decision making. Where to pass the ball to, when to shoot.

        public Player(int Number, string Position, int Pace, int Shooting, int Passing, int Dribble, int Defence,
                      int Intelligence)
        {
            this.Number         = Number;
            this.Position       = Position;
            this.Pace = Pace;             // Speed/SPD
            this.Shooting = Shooting;         // Attack/ATK
            this.Passing = Passing;
            this.Dribble = Dribble;
            this.Defence = Defence;          // Defense/DEF
            this.Intelligence   = Intelligence;
            this.HasBall        = false;
        }


        /// <summary>
        /// Make dicision while in possesion of the ball, Where to pass the ball or when to shoot. Based on intelligence.
        /// </summary>
        public void MakeDecision()
        {
            bool goodDecision;

            // Calculate bad or good decision
            if (random.Next(1, 100) > this.Intelligence)
            {
                goodDecision = true;
            }
            else
            {
                goodDecision = false;
            }


            if (goodDecision == true) // Good Decision
            {
                if(this.Position == "Attacker")
                {
                    if (random.Next(1, 100) > this.Dribble)
                    {
                        ShootOnGoal(DribbleWithBall());
                    }
                    ShootOnGoal(false);  
                }
                if(this.Position == "Defender")
                {
                    if (random.Next(1, 100) > this.Dribble)
                    {
                        PassBall(DribbleWithBall());
                    }
                    PassBall(false);
                }
                if(this.Position == "Midfielder")
                {
                    if (random.Next(1, 100) > this.Dribble)
                    {
                        PassBall(DribbleWithBall());
                    }
                    PassBall(false);
                }   
            }
            if(goodDecision == false) // Bad Decision
            {
                if (this.Position == "Attacker")
                {
                    PassBall(false);
                }
                if (this.Position == "Defender")
                {
                    ShootOnGoal(false);
                }
                if (this.Position == "Midfielder")
                {
                    ShootOnGoal(false);
                }
            }
        }

        /// <summary>
        /// Succes rate is based on player possition, shooting skill and Dribble skill.
        /// </summary>
        /// <param name="dribbleBonus"></param>
        /// <returns></returns>
        public bool ShootOnGoal(bool dribbleBonus)
        {
            int currentShootingSkill = this.Shooting;

            if (dribbleBonus == true) { 
                currentShootingSkill += 10; 
            }
            if (random.Next(1, 100) > currentShootingSkill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Succes rate is based on player passing skill, dribble skill
        /// </summary>
        public bool PassBall(bool dribbleBonus)
        {
            int currenPassingSkill = this.Shooting;

            if (dribbleBonus == true)
            {
                currenPassingSkill += 10;
            }

            if (random.Next(1, 100) > currenPassingSkill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Dribble ball to improve shooting or passing opportunity if dribble succeeds, lose ball if dribble fails.
        /// </summary>
        public bool DribbleWithBall()
        {
            if(random.Next(1, 100) > this.Dribble)
            {
                return false;
            }
            return true;
        }
    }
}
