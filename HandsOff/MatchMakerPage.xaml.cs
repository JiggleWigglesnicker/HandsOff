using HandsOff.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
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
        private readonly List<Match> Matches = new List<Match>();

        private Team SelectedTeam1;
        private Team SelectedTeam2;
        private string TeamName;

        public MatchMaker()
        {
            InitializeComponent();
            EnterTeamsIntoDropBox();
        }

        /// <summary>
        /// this method fills in all the existing teams in the list into the dropboxes
        /// </summary>
        public void EnterTeamsIntoDropBox()
        {
            ComboBox CB1 = TeamCB1;
            ComboBox CB2 = TeamCB2;

            foreach (Team Team in App.Teams)
            {
                CB1.Items.Add(Team.TeamName);
                CB2.Items.Add(Team.TeamName);

                if (Team != null)
                {
                    CB1.SelectedIndex = 0;
                    CB2.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Invoked when a team is selected in dropdownbox 1. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamCB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeamName = e.AddedItems[0].ToString();

            foreach (Team team in App.Teams)
            {
                if (TeamName == team.TeamName)
                {
                    SelectedTeam1 = team;
                }
            }
        }

        /// <summary>
        /// Invoked when a team is selected in dropdownbox 2. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamCB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeamName = e.AddedItems[0].ToString();

            foreach (Team Team in App.Teams)
            {
                if (TeamName == Team.TeamName)
                {
                    SelectedTeam2 = Team;
                }
            }
        }

        /// <summary>
        /// Creates new Match using the two selected teams.
        /// </summary>
        public async void MakeMatch()
        {
            int AmountOfMatches = (int)long.Parse(NumberOfMatches.Text);

            if (AmountOfMatches > 100)
            {
                //Show dialog if only one or no teams are selected.
                MessageDialog showDialog = new MessageDialog("Kies een getal onder de 100");
                showDialog.Commands.Add(new UICommand("Ok")
                {
                    Id = 0
                });
                showDialog.DefaultCommandIndex = 0;
                IUICommand result = await showDialog.ShowAsync();
                if ((int)result.Id == 0)
                {
                    return;
                }
            }

            // instantiates the amount of matches selected during matchmaking.
            while (AmountOfMatches > 0)
            {
                Match match = new Match(SelectedTeam1, SelectedTeam2);
                Matches.Add(match);
                AmountOfMatches--;
            }
            Frame.Navigate(typeof(SimulationExecution), Matches);
        }

        /// <summary>
        /// When the match click button is pressed check if teams chosen and execute MakeMatch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Make_Match_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTeam1 == null || SelectedTeam2 == null)
            {
                //Show dialog if only one or no teams are selected.
                MessageDialog showDialog = new MessageDialog("Kies 2 teams");
                showDialog.Commands.Add(new UICommand("Ok")
                {
                    Id = 0
                });

                showDialog.DefaultCommandIndex = 0;
                IUICommand result = await showDialog.ShowAsync();
                if ((int)result.Id == 0)
                {
                    return;
                }
            }

            MakeMatch();
        }

        /// <summary>
        /// Navigates back to the previous Frame (Page)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}
