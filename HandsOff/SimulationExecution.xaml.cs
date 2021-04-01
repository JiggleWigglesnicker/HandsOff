using HandsOff.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class SimulationExecution : Page
    {
        public List<Match> matches = new List<Match>();

        public SimulationExecution()
        {
            this.InitializeComponent();
        }

        public void CreateMatchListUI()
        {
            StackPanel stackPanel = this.MatchList;
            int i = 1;

            foreach (Match match in matches)
            {
                ListView listView = new ListView();
                listView.IsHitTestVisible = false;
                listView.HorizontalAlignment = HorizontalAlignment.Center;
                listView.Width = 350;
                TextBlock textBlock1 = new TextBlock();
                textBlock1.Foreground = new SolidColorBrush(Colors.White);
                textBlock1.FontSize = 45;
                textBlock1.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock1.Text = "Match" + i;
                textBlock1.Height = 50;
                textBlock1.Width = 200;
                textBlock1.Margin = new Thickness(0, 50, 0, 0);
                TextBlock textBlock2 = new TextBlock();
                textBlock2.Foreground = new SolidColorBrush(Colors.White);
                textBlock2.FontSize = 15;
                textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock2.Text = match.team1.TeamName + " VS " + match.team2.TeamName;
                textBlock2.Height = 50;
                textBlock2.Width = 250;
                textBlock2.Margin = new Thickness(0, 20, 0, 10);
                TextBlock textBlock3 = new TextBlock();
                textBlock3.Foreground = new SolidColorBrush(Colors.White);
                textBlock3.FontSize = 35;
                textBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock3.Text = "Progress";
                textBlock3.Height = 50;
                textBlock3.Width = 250;
                textBlock3.Margin = new Thickness(0, 10, 0, 0);
                ProgressBar progressB = new ProgressBar();
                progressB.Name = "ProgressBar" + i;
                //progressB.Foreground = new SolidColorBrush(Colors.White);
                //progressB.Background = new SolidColorBrush(Colors.Black);
                progressB.IsIndeterminate = false;
                progressB.Minimum = 0;
                progressB.Maximum = 200;
                //progressB.FontSize = 35;
                //progressB.HorizontalAlignment = HorizontalAlignment.Center;
                progressB.Height = 50;
                progressB.Width = 250;
                progressB.Margin = new Thickness(0, 0, 0, 20);
                i++;

                stackPanel.Children.Add(listView);
                listView.Items.Add(textBlock1);
                listView.Items.Add(textBlock2);
                listView.Items.Add(textBlock3);
                listView.Items.Add(progressB);
            }
        }

        public void updateProgressBar(int progress) {

            int i = 1; 

            foreach (Match match in matches)
            {
                ProgressBar progressB = (ProgressBar)this.FindName("ProgressBar" + i);
                progressB.Value += progress;
                i++;
            }
        }

        public async void StartExecution()
        {
            Debug.WriteLine("Starting simulation(s) now!");
            foreach (Match match in matches)
            {
                var progressIndicator = new Progress<int>(updateProgressBar);
                await match.StartSimulationAsync(progressIndicator);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                this.matches = (List<Match>)e.Parameter;
                CreateMatchListUI();
            }
        }

        public void StartSim_Click(object sender, RoutedEventArgs e) {

            StartExecution();
        }
    }
}
