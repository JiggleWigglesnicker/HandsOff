namespace HandsOff.Models
{
    public class Player
    {
        public int Number { get; set; }
        public int Pace { get; set; }
        public int Shooting { get; set; }
        public int Defence { get; set; }

        public Player(int Number, int Pace, int Shooting, int Defence)
        {
            this.Number = Number;       // Number refers to the role of the player: players 1-4 are defenders, 5-7 are midfielders, and 8-10 are attackers, 11 is the keeper
            this.Pace = Pace;           // Speed/SPD
            this.Shooting = Shooting;   // Attack/ATK
            this.Defence = Defence;     // Defense/DEF
        }
    }
}
