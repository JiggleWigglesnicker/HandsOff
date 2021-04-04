using HandsOff.Models;
using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamCreator : Page
    {
        

        public TeamCreator()
        {
            this.InitializeComponent();
            TeamPageUIAsync();
        }

        public async void TeamPageUIAsync()
        {
            await Task.Run(() =>
            {
                CreateTeamCreatorUI();
            });
        }

        public async void CreateTeamCreatorUI()
        {
            int x = 0;
            Grid grid = this.TeamGrid;
            for (int i = 1; i < 12; i++)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ScrollViewer scrollView = new ScrollViewer();

                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Name = "stackpanel" + i;

                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = "Player " + i;
                    textBlock1.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock1.FontSize = 40;
                    textBlock1.Foreground = new SolidColorBrush(Colors.White);

                    TextBlock textBlock2 = new TextBlock();
                    textBlock2.Text = "Speed";
                    textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock2.FontSize = 30;
                    textBlock2.Foreground = new SolidColorBrush(Colors.White);
                    textBlock2.Margin = new Thickness(15, 5, 0, 0);

                    TextBlock textBlock3 = new TextBlock();
                    textBlock3.Text = "Attack";
                    textBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock3.FontSize = 30;
                    textBlock3.Foreground = new SolidColorBrush(Colors.White);
                    textBlock3.Margin = new Thickness(15, 2, 0, 0);

                    TextBlock textBlock6 = new TextBlock();
                    textBlock6.Text = "Defence";
                    textBlock6.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock6.FontSize = 30;
                    textBlock6.Foreground = new SolidColorBrush(Colors.White);
                    textBlock6.Margin = new Thickness(15, 2, 0, 0);
                    
                    TextBox textBox1 = new TextBox();
                    textBox1.Text = "0";
                    textBox1.Background = new SolidColorBrush(Colors.Wheat);
                    textBox1.Foreground = new SolidColorBrush(Colors.Black);
                    textBox1.FontSize = 20;
                    textBox1.Height = 35;
                    textBox1.Width = 75;

                    TextBox textBox2 = new TextBox();
                    textBox2.Text = "0";
                    textBox2.Background = new SolidColorBrush(Colors.Wheat);
                    textBox2.Foreground = new SolidColorBrush(Colors.Black);
                    textBox2.FontSize = 20;
                    textBox2.Height = 35;
                    textBox2.Width = 75;

                    TextBox textBox5 = new TextBox();
                    textBox5.Text = "0";
                    textBox5.Background = new SolidColorBrush(Colors.Wheat);
                    textBox5.Foreground = new SolidColorBrush(Colors.Black);
                    textBox5.FontSize = 20;
                    textBox5.Height = 35;
                    textBox5.Width = 75;

                    grid.Children.Add(scrollView);
                    scrollView.Content = stackPanel;
                    stackPanel.Children.Add(textBlock1);
                    stackPanel.Children.Add(textBlock2);
                    stackPanel.Children.Add(textBox1);
                    stackPanel.Children.Add(textBlock3);
                    stackPanel.Children.Add(textBox2);
                    stackPanel.Children.Add(textBlock6);
                    stackPanel.Children.Add(textBox5);

                    if (i <= 4)
                    {
                        Grid.SetColumn(scrollView, x);
                        Grid.SetRow(scrollView, 0);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 4 && i < 9)
                    {
                        Grid.SetColumn(scrollView, x);
                        Grid.SetRow(scrollView, 1);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i >= 9)
                    {
                        if (i == 9)
                        {
                            x++;
                        }

                        Grid.SetColumn(scrollView, x);
                        Grid.SetRow(scrollView, 2);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                });
            }
        }

        private void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            App.teams.Add(CreateCustomTeam());
        }

        public Team CreateCustomTeam()
        {
            Team team = new Team();
            team.TeamName = TeamNameBox.Text;

            for (int i = 1; i < 12; i++)
            {
                StackPanel stackpanel = (StackPanel)this.FindName("stackpanel" + i);
                TextBox textBox1 = (TextBox)stackpanel.Children[2];
                TextBox textBox2 = (TextBox)stackpanel.Children[4];
                TextBox textBox5 = (TextBox)stackpanel.Children[6];
                int pace = (int)Int64.Parse(textBox1.Text);
                int shooting = (int)Int64.Parse(textBox2.Text);
                int defence = (int)Int64.Parse(textBox5.Text);

                Player player = new Player(i, pace, shooting, defence);
                team.AddPlayerToTeam(player);
            }
            return team;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}