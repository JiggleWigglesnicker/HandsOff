using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOff.Models
{
    public class MatchPool
    {
        public List<Match> Matches = new List<Match>();

        public MatchPool()
        {

        }
        
        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public void StartExecution()
        {
            Debug.WriteLine("Starting simulation(s) now!");
            foreach (Match match in Matches)
            {
                match.StartSimulation();
            }
        }
    }
}