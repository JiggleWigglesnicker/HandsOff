namespace HandsOff.Models
{
    public class Player
    {
        public int Number { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defence { get; set; }

        public Player(int Number, int Attack, int Speed, int Defence)
        {
            this.Number = Number;       // Number refers to the role of the player: players 1-4 are defenders, 5-7 are mid-fielders, and 8-10 are attackers, 11 is the keeper
            this.Attack = Attack;       // Attack/ATK
            this.Speed = Speed;         // Speed/SPD
            this.Defence = Defence;     // Defense/DEF
        }
    }
}
