using HandsOff.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
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
        public ProgressBar BigBar;

        public SimulationExecution()
        {
            this.InitializeComponent();
            BigBar = this.AllBar;
        }

        public void CreateMatchListUI()
        {
            Task.Run(() =>
            {
                StackPanel Stackpanel1 = this.MatchList1;
                StackPanel Stackpanel2 = this.MatchList2;
                StackPanel Stackpanel3 = this.MatchList3;

                int i = 1;
                int x = 0;

                Parallel.ForEach(Matches, async match =>
                {
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
                            Text = "Match" + i,
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
                        BigBar.Maximum = Matches.Count();
                    });
                });
            });
        }

        public async void StartExecution()
        {
            int i = 1;
            await Task.Run(() =>
            {
                Parallel.ForEach(Matches, async match =>
                {
                    match.StartSimulation();

                    await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                    {
                        ProgressBar bar = (ProgressBar)this.FindName("ProgressBar" + i);
                        bar.Value = match.TurnCounter;
                        i++;
                        BigBar.Value += 1;
                    });
                });


            });

            Button nextbutton = (Button)this.continueButton;

            nextbutton.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                this.Matches = (List<Match>)e.Parameter;
                CreateMatchListUI();
            }
        }

        public void StartSim_Click(object sender, RoutedEventArgs e)
        {
            StartExecution();
            startSimButton.Visibility = Visibility.Collapsed;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SimulationPage));
        }
    }
}