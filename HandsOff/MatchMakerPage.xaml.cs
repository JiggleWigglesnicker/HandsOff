using HandsOff.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchMaker : Page
    {
        List<Team> Teams = new List<Team>();

        public MatchMaker()
        {
            Teams.Add(App.team1);
            Teams.Add(App.team2);
            Teams.Add(App.team3);

            this.InitializeComponent();
            enterTeamsIntoDropBox();

            //CreateDropBoxTeams();
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
                CB1.Items.Add(team);
                CB2.Items.Add(team);

                Console.WriteLine("added team {0}", team.getName());
            }
        }

        public void CreateDropBoxTeams()
        {
            ComboBox CB1 = this.TeamCB1;
            ComboBox CB2 = this.TeamCB2;
            CB1.Items.Add(App.team1.getName());
            CB1.Items.Add(App.team2.getName());
            CB1.Items.Add(App.team3.getName());
            CB2.Items.Add(App.team1.getName());
            CB2.Items.Add(App.team2.getName());
            CB2.Items.Add(App.team3.getName());

            Teams.Add(App.team1);
            Teams.Add(App.team2);
            Teams.Add(App.team3);
        }

        public void AddTeamToList(Team team)
        {
            Teams.Add(team);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void TeamCB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TeamCB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
