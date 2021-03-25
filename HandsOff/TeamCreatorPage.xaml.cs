using HandsOff.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
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
    public sealed partial class TeamCreator : Page
    {
        private Team team { get; set; }

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
                    textBlock2.Text = "Pace";
                    textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock2.FontSize = 30;
                    textBlock2.Foreground = new SolidColorBrush(Colors.White);
                    textBlock2.Margin = new Thickness(15, 5, 0, 0);
                    TextBlock textBlock3 = new TextBlock();
                    textBlock3.Text = "Shooting";
                    textBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock3.FontSize = 30;
                    textBlock3.Foreground = new SolidColorBrush(Colors.White);
                    textBlock3.Margin = new Thickness(15, 2, 0, 0);
                    TextBlock textBlock4 = new TextBlock();
                    textBlock4.Text = "Passing";
                    textBlock4.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock4.FontSize = 30;
                    textBlock4.Foreground = new SolidColorBrush(Colors.White);
                    textBlock4.Margin = new Thickness(15, 2, 0, 0);
                    TextBlock textBlock5 = new TextBlock();
                    textBlock5.Text = "Dribble";
                    textBlock5.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock5.FontSize = 30;
                    textBlock5.Foreground = new SolidColorBrush(Colors.White);
                    textBlock5.Margin = new Thickness(15, 2, 0, 0);
                    TextBlock textBlock6 = new TextBlock();
                    textBlock6.Text = "Defence";
                    textBlock6.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock6.FontSize = 30;
                    textBlock6.Foreground = new SolidColorBrush(Colors.White);
                    textBlock6.Margin = new Thickness(15, 2, 0, 0);
                    TextBlock textBlock7 = new TextBlock();
                    textBlock7.Text = "Intelligence";
                    textBlock7.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock7.FontSize = 30;
                    textBlock7.Foreground = new SolidColorBrush(Colors.White);
                    textBlock7.Margin = new Thickness(15, 2, 0, 0);
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
                    TextBox textBox3 = new TextBox();
                    textBox3.Text = "0";
                    textBox3.Background = new SolidColorBrush(Colors.Wheat);
                    textBox3.Foreground = new SolidColorBrush(Colors.Black);
                    textBox3.FontSize = 20;
                    textBox3.Height = 35;
                    textBox3.Width = 75;
                    TextBox textBox4 = new TextBox();
                    textBox4.Text = "0";
                    textBox4.Background = new SolidColorBrush(Colors.Wheat);
                    textBox4.Foreground = new SolidColorBrush(Colors.Black);
                    textBox4.FontSize = 20;
                    textBox4.Height = 35;
                    textBox4.Width = 75;
                    TextBox textBox5 = new TextBox();
                    textBox5.Text = "0";
                    textBox5.Background = new SolidColorBrush(Colors.Wheat);
                    textBox5.Foreground = new SolidColorBrush(Colors.Black);
                    textBox5.FontSize = 20;
                    textBox5.Height = 35;
                    textBox5.Width = 75;
                    TextBox textBox6 = new TextBox();
                    textBox6.Text = "0";
                    textBox6.Background = new SolidColorBrush(Colors.Wheat);
                    textBox6.Foreground = new SolidColorBrush(Colors.Black);
                    textBox6.FontSize = 20;
                    textBox6.Height = 35;
                    textBox6.Width = 75;


                    grid.Children.Add(scrollView);
                    scrollView.Content = stackPanel;
                    stackPanel.Children.Add(textBlock1);
                    stackPanel.Children.Add(textBlock2);
                    stackPanel.Children.Add(textBox1);
                    stackPanel.Children.Add(textBlock3);
                    stackPanel.Children.Add(textBox2);
                    stackPanel.Children.Add(textBlock4);
                    stackPanel.Children.Add(textBox3);
                    stackPanel.Children.Add(textBlock5);
                    stackPanel.Children.Add(textBox4);
                    stackPanel.Children.Add(textBlock6);
                    stackPanel.Children.Add(textBox5);
                    stackPanel.Children.Add(textBlock7);
                    stackPanel.Children.Add(textBox6);

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

        public Team CreateTeam()
        {
            Team team = new Team();
            for (int i = 1; i < 12; i++)
            {
                StackPanel stackpanel = (StackPanel)this.FindName("stackpanel" + i);
                TextBox textBox1 = (TextBox)stackpanel.Children[2];
                TextBox textBox2 = (TextBox)stackpanel.Children[4];
                TextBox textBox3 = (TextBox)stackpanel.Children[6];
                TextBox textBox4 = (TextBox)stackpanel.Children[8];
                TextBox textBox5 = (TextBox)stackpanel.Children[10];
                TextBox textBox6 = (TextBox)stackpanel.Children[12];
                int pace = (int)Int64.Parse(textBox1.Text);
                int shooting = (int)Int64.Parse(textBox2.Text);
                int passing = (int)Int64.Parse(textBox3.Text);
                int dribble = (int)Int64.Parse(textBox4.Text);
                int defence = (int)Int64.Parse(textBox5.Text);
                int intelligence = (int)Int64.Parse(textBox6.Text);
                String Position = "Attacker";
                Player player = new Player(i, Position, pace, shooting, passing, dribble, defence, intelligence);
                team.addPlayerToTeam(player);
            }
            return team;
        }

        private void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            team = CreateTeam();
            team.TeamName = TeamNameBox.Text;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}
