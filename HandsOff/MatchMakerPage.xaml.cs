using HandsOff.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchMaker : Page
    {
        readonly List<Team> Teams = new List<Team>();
        readonly List<Match> matches = new List<Match>();

        Team SelectedTeam1;
        Team SelectedTeam2;

        public MatchMaker()
        {
            Teams.Add(App.team1);
            Teams.Add(App.team2);
            Teams.Add(App.team3);

            this.InitializeComponent();
            enterTeamsIntoDropBox();
        }

        /// <summary>
        /// this method fills in all the existing teams in the list into the dropboxes
        /// </summary>
        public void enterTeamsIntoDropBox()
        {
            ComboBox CB1 = this.TeamCB1;
            ComboBox CB2 = this.TeamCB2;

            foreach (Team team in Teams)
            {
                CB1.Items.Add(team.getName());
                CB2.Items.Add(team.getName());
            }
        }

        public void CreateDropBoxTeams()
        {
            ComboBox CB1 = this.TeamCB1;
            ComboBox CB2 = this.TeamCB2;

            // fill in teams for ComboBox 1
            CB1.Items.Add(App.team1.getName());
            CB1.Items.Add(App.team2.getName());
            CB1.Items.Add(App.team3.getName());
            // fill in teams for ComboBox 2
            CB2.Items.Add(App.team1.getName());
            CB2.Items.Add(App.team2.getName());
            CB2.Items.Add(App.team3.getName());

            Teams.Add(App.team1);
            Teams.Add(App.team2);
            Teams.Add(App.team3);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void TeamCB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String teamName = e.AddedItems[0].ToString();

            foreach (Team team in Teams)
            {
                if (teamName == team.getName())
                {
                    SelectedTeam1 = team;
                    //Debug.WriteLine("Selected as team 1: {0} with Team name: {1}", SelectedTeam1, teamName);
                }
            }
        }

        private void TeamCB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String teamName = e.AddedItems[0].ToString();

            foreach (Team team in Teams)
            {
                if (teamName == team.getName())
                {
                    SelectedTeam2 = team;
                    //Debug.WriteLine("Selected as team 1: {0} with Team name: {1}", SelectedTeam1, teamName);
                }
            }
        }

        public void MakeMatch()
        {
            int AmountOfMatches = (int)Int64.Parse(NumberOfMatches.Text);

            while (AmountOfMatches > 0)
            {
                Match match = new Match(SelectedTeam1, SelectedTeam2);
                matches.Add(match);

                //Debug.WriteLine("Added match to list! numbers left: {0}", AmountOfMatches);
                AmountOfMatches--;
            }
        }

        private void Make_Match_Click(object sender, RoutedEventArgs e)
        {
            MakeMatch();
            this.Frame.Navigate(typeof(SimulationExecution), matches);
        }
    }
}
