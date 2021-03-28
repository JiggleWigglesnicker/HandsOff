using HandsOff.Models;
using System;
using System.Collections.Generic;
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
        public MatchPool matchPool = new MatchPool();

        public SimulationExecution()
        {
            this.InitializeComponent();

        }

        public void CreateMatchListUI()
        {
            StackPanel stackPanel = this.MatchList;
            int i = 1;

            foreach (Match match in matchPool.Matches)
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
                TextBlock textBlock4 = new TextBlock();
                textBlock4.Name = "ProgressBar" + i;
                textBlock4.Foreground = new SolidColorBrush(Colors.White);
                textBlock4.FontSize = 35;
                textBlock4.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock4.Text = "+";
                textBlock4.Height = 50;
                textBlock4.Width = 250;
                textBlock4.Margin = new Thickness(0, 0, 0, 20);
                i++;

                stackPanel.Children.Add(listView);
                listView.Items.Add(textBlock1);
                listView.Items.Add(textBlock2);
                listView.Items.Add(textBlock3);
                listView.Items.Add(textBlock4);


            }
        }

        public void updateProgressBar() {

            int i = 1;

            foreach (Match match in matchPool.Matches)
            {
                TextBlock textBlockProgress = (TextBlock)this.FindName("ProgressBar" + i);
                textBlockProgress.Text += match.ProgressString;
                i++;
            }
        
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                this.matchPool = (MatchPool)e.Parameter;
                CreateMatchListUI();
            }
        }

        private void StartSim_Click(object sender, RoutedEventArgs e)
        {
            matchPool.StartExecution();
        }
    }
}
