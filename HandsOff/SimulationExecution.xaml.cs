using HandsOff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        public List<Match> Matches = new List<Match>();
        public ProgressBar ProgressBarTotalMatches;

        public SimulationExecution()
        {
            InitializeComponent();
            ProgressBarTotalMatches = AllBar;
        }

        /// <summary>
        /// Creates GUI elements foreach match that is to be simulated, async.
        /// </summary>
        public void CreateMatchListUI()
        {
            Task.Run(() =>
            {
                StackPanel Stackpanel1 = MatchList1;
                StackPanel Stackpanel2 = MatchList2;
                StackPanel Stackpanel3 = MatchList3;

                int i = 1;
                int x = 0;

                Parallel.ForEach(Matches, async match =>
                {
                    // Returns back to the UI thread to updated GUI.
                    await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                    {
                        ListView listView = new ListView
                        {
                            IsHitTestVisible = false,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Width = 350
                        };

                        TextBlock textBlock1 = new TextBlock
                        {
                            Foreground = new SolidColorBrush(Colors.White),
                            FontSize = 18,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Text = "Match " + i,
                            Height = 50,
                            Width = 200,
                            Margin = new Thickness(0, 40, 0, 0)
                        };

                        TextBlock textBlock2 = new TextBlock
                        {
                            Foreground = new SolidColorBrush(Colors.White),
                            FontSize = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Text = match.Team1.TeamName + " VS " + match.Team2.TeamName,
                            Height = 50,
                            Width = 250,
                            Margin = new Thickness(0, 5, 0, -35)
                        };

                        TextBlock textBlock3 = new TextBlock
                        {
                            Foreground = new SolidColorBrush(Colors.White),
                            FontSize = 18,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Text = "Progress",
                            Height = 50,
                            Width = 250,
                            Margin = new Thickness(0, 0, 0, 0)
                        };

                        ProgressBar progressB = new ProgressBar
                        {
                            Name = "ProgressBar" + i,
                            IsIndeterminate = false,
                            Minimum = 0,
                            Maximum = 3500000,
                            Height = 25,
                            Width = 250,
                            Margin = new Thickness(0, 0, 0, 0)
                        };
                        i++;

                        switch (x)
                        {
                            case 1:
                                Stackpanel2.Children.Add(listView);
                                listView.Items.Add(textBlock1);
                                listView.Items.Add(textBlock2);
                                listView.Items.Add(textBlock3);
                                listView.Items.Add(progressB);
                                x++;
                                break;
                            case 2:
                                Stackpanel3.Children.Add(listView);
                                listView.Items.Add(textBlock1);
                                listView.Items.Add(textBlock2);
                                listView.Items.Add(textBlock3);
                                listView.Items.Add(progressB);
                                x++;
                                break;
                            default:
                                x = 0;
                                Stackpanel1.Children.Add(listView);
                                listView.Items.Add(textBlock1);
                                listView.Items.Add(textBlock2);
                                listView.Items.Add(textBlock3);
                                listView.Items.Add(progressB);
                                x++;
                                break;
                        }
                        ProgressBarTotalMatches.Maximum = Matches.Count();
                    });
                });
            });
        }

        /// <summary>
        /// When invoked starts simulating matches async.
        /// </summary>
        public async void StartExecution()
        {
            int i = 1;
            await Task.Run(() =>
            {
                Parallel.ForEach(Matches, async match =>
                {
                    match.StartSimulation();

                    // Returns back to the UI thread to update the GUI progress bars.
                    await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                    {
                        ProgressBar bar = (ProgressBar)FindName("ProgressBar" + i);
                        bar.Value = match.TurnCounter;
                        i++;
                        ProgressBarTotalMatches.Value += 1;
                    });
                });
            });

            Button nextbutton = continueButton;

            nextbutton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Invoked when Navigated to this page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                Matches = (List<Match>)e.Parameter;
                CreateMatchListUI();
            }
        }

        /// <summary>
        /// Simulates the matches when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartSim_Click(object sender, RoutedEventArgs e)
        {
            StartExecution();
            startSimButton.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Navigates to the simulation overview when all matches complete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SimulationPage));
        }

        /// <summary>
        /// Navigates back to the previous page (Frame).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}