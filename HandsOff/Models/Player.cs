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
        public int Pace { get; set; } // Player Skills are based on a scale of 1 - 99
        public int Shooting { get; set; }
        public int Passing { get; set; }
        public int Dribble { get; set; }
        public int Defence { get; set; }
        public int Intelligence { get; set; } // Intelligence improves decision making. Where to pass the ball to, when to shoot.


        /// <summary>
        /// Make dicision while in possesion of the ball, Where to pass the ball or when to shoot. Based on intelligence.
        /// </summary>
        public void MakeDecision()
        {
            bool Decision;
            // Calculate bad or good decision
            Decision = true;


            if(Decision == true) // Good Decision
            {
                if(this.Possition == "Attacker")
                {
                    ShootOnGoal();
                }
                if(this.Possition == "Defender")
                {
                    PassBall();
                }
                if(this.Possition == "Midfielder")
                {
                    PassBall();
                }
                
            }
            if(Decision == false) // Bad Decision
            {
                if (this.Possition == "Attacker")
                {
                    PassBall();
                }
                if (this.Possition == "Defender")
                {
                    ShootOnGoal();
                }
                if (this.Possition == "Midfielder")
                {
                    ShootOnGoal();
                }
            }

        }


        /// <summary>
        /// Succes rate is based on player possition, shooting skill and Dribble skill.
        /// </summary>
        public void ShootOnGoal()
        {

        }
        /// <summary>
        /// Succes rate is based on player passing skill, dribble skill, and 
        /// </summary>
        public void PassBall()
        {

        }

    }
}
