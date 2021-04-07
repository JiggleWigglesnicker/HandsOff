namespace HandsOff.Models
{
    public class Player
    {
        public int Number { get; set; }
        public string Position { get; set; } // this refers to the role of the player; players 1-2-3-4 defenders, 5, 6, 7, are midfielders, and 8, 9, 10 are attackers, 11 is keeper
        public int Pace { get; set; }
        public int Shooting { get; set; }
        public int Defence { get; set; }
        //public int Luck { get; set; }

        public Player(int Number, int Pace, int Shooting, int Defence)
        {
            this.Number = Number;
            this.Pace = Pace;           // Speed/SPD
            this.Shooting = Shooting;   // Attack/ATK
            this.Defence = Defence;     // Defense/DEF
        }
    }
}
