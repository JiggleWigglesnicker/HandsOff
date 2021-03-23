using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    class Player
    {
        public int Number { get; set; }
        public string Possition { get; set; }
        public bool HasBall { get; set; }

        /// Player Skills are based on a scale of 1 - 99
        public int Pace { get; set; } =55;
        public int Shooting { get; set; } = 55;
        public int Passing { get; set; } = 55;
        public int Dribble { get; set; } = 55;
        public int Defence { get; set; } = 55;
        public int Intelligence { get; set; } = 55; // Intelligence improves decision making. Where to pass the ball to, when to shoot.
        public int positition { get; set; } = 0; // this refers to the role of the player; players 1-4 defenders, 4, 5, 6, are midfielders, and 7, 8, 10 are attackers

        public Player(int Number, string Possition, int Pace, int Shooting, int Passing, int Dribble, int Defence, int Intelligence)
        {
            this.Number = Number;
            this.Possition = Possition;
            this.Pace = Pace;
            this.Shooting = Shooting;
            this.Passing = Passing;
            this.Dribble = Dribble;
            this.Defence = Defence;
            this.Intelligence = Intelligence;
            this.HasBall = false;
        }

        /// <summary>
        /// Make dicision while in possesion of the ball, Where to pass the ball or when to shoot. Based on intelligence.
        /// </summary>
        public void MakeDecision()
        {
            bool goodDecision;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            // Calculate bad or good decision
            goodDecision = true; 

            if (goodDecision == true) // Good Decision
            {
                if(this.Possition == "Attacker")
                {
                    if (randomNumber > this.Dribble)
                    {
                        ShootOnGoal(DribbleWithBall());
                    }
                    ShootOnGoal(false);
                    
                }
                if(this.Possition == "Defender")
                {
                    if (randomNumber > this.Dribble)
                    {
                        PassBall(DribbleWithBall());
                    }
                    PassBall(false);
                }
                if(this.Possition == "Midfielder")
                {
                    if (randomNumber > this.Dribble)
                    {
                        PassBall(DribbleWithBall());
                    }
                    PassBall(false);
                }   
            }
            if(goodDecision == false) // Bad Decision
            {
                if (this.Possition == "Attacker")
                {
                    PassBall(false);
                }
                if (this.Possition == "Defender")
                {
                    ShootOnGoal(false);
                }
                if (this.Possition == "Midfielder")
                {
                    ShootOnGoal(false);
                }
            }

        }


        /// <summary>
        /// Succes rate is based on player possition, shooting skill and Dribble skill.
        /// </summary>
        public void ShootOnGoal(bool dribbleBonus)
        {
            int currentShootingSkill = this.Shooting;
            if(dribbleBonus == true) { 
                currentShootingSkill += 10; 
            }
        }

        /// <summary>
        /// Succes rate is based on player passing skill, dribble skill, and 
        /// </summary>
        public bool PassBall(bool dribbleBonus)
        {
            bool succesfullPass;
            int currenPassingSkill = this.Shooting;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);


            if (dribbleBonus == true)
            {
                currenPassingSkill += 10;
            }

            if (randomNumber > this.Passing)
            {
                succesfullPass = true;
            }
            else
            {
                succesfullPass = false;
            }

            return succesfullPass;
        }

        /// <summary>
        /// Dribble ball to improve shooting or passing opportunity if dribble succeeds, lose ball if dribble fails.
        /// </summary>
        public bool DribbleWithBall()
        {
            bool result = true;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);


            if(randomNumber > this.Dribble)
            {
                result = false;
            }

            return result;
        }

    }
}
