namespace DataAccessLibrary
{
    public class Score
    {
        public string TeamName1 { get; set; }
        public string TeamName2 { get; set; }
        public int TeamScore1 { get; set; }
        public int TeamScore2 { get; set; }

        public Score(string teamname1, string teamname2, int teamscore1, int teamscore2)
        {
            TeamName1 = teamname1;
            TeamName2 = teamname2;
            TeamScore1 = teamscore1;
            TeamScore2 = teamscore2;
        }
    }
}
