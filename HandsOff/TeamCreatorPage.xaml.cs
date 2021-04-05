﻿using HandsOff.Models;
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
        readonly string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "Fc MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "C# Masters", "UWP 4 Life", "Fc Frenkie", "VV Baptist", "James Blunt's Boys", "Ltjes Rozenwater", "Fc Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood", "FC Schoonebeek", "De Sonurs", "De Multithreaders" };
        readonly System.Random randomNumber = new System.Random();
        String RandomTeamName;

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

                    StackPanel stackPanel = new StackPanel
                    {
                        Name = "stackpanel" + i
                    };

                    TextBlock playerLabel = new TextBlock
                    {
                        Text = "Player " + i,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 40,
                        Foreground = new SolidColorBrush(Colors.White)
                    };

                    TextBlock speedLabel = new TextBlock
                    {
                        Text = "Speed",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 30,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 5, 0, 0)
                    };

                    TextBlock attackLabel = new TextBlock
                    {
                        Text = "Attack",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 30,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 2, 0, 0)
                    };

                    TextBlock defenceLabel = new TextBlock
                    {
                        Text = "Defence",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 30,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 2, 0, 0)
                    };

                    TextBox speedTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        Height = 35,
                        Width = 75
                    };

                    TextBox attackTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        Height = 35,
                        Width = 75
                    };

                    TextBox defenceTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        Height = 35,
                        Width = 75
                    };

                    grid.Children.Add(scrollView);
                    scrollView.Content = stackPanel;
                    stackPanel.Children.Add(playerLabel);
                    stackPanel.Children.Add(speedLabel);
                    stackPanel.Children.Add(speedTextBox);
                    stackPanel.Children.Add(attackLabel);
                    stackPanel.Children.Add(attackTextBox);
                    stackPanel.Children.Add(defenceLabel);
                    stackPanel.Children.Add(defenceTextBox);

                    if (i <= 1)
                    {
                        Grid.SetColumn(scrollView, x + 2);
                        Grid.SetRow(scrollView, 3);

                        x++;

                        if (x == 1)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 1 && i <= 5)
                    {
                        Grid.SetColumn(scrollView, x +1);
                        Grid.SetRow(scrollView, 2);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 5 && i <= 9)
                    {
                        Grid.SetColumn(scrollView, x +1);
                        Grid.SetRow(scrollView, 1);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 9)
                    {
                   

                        Grid.SetColumn(scrollView, x +2);
                        Grid.SetRow(scrollView, 0);

                        x++;

                        if (x == 2)
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
            Team team = new Team
            {
                TeamName = TeamNameBox.Text
            };

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

        private void CreateRandomTeam_Click(object sender, RoutedEventArgs e)
        {
            Team RandomTeam = CreateTeam();

            RandomTeam.TeamName = Generate_TeamName();
            App.teams.Add(RandomTeam);
        }

        public String Generate_TeamName()
        {
            RandomTeamName =  TeamNames[randomNumber.Next(0, TeamNames.Length - 1)];

            return RandomTeamName;
        }

        public Team CreateTeam()
        {
            System.Random randomSkill = new System.Random();

            Team team = new Team();
            int shooting;
            int pace;
            int defence;

            for (int i = 1; i < 12; i++)
            {
                switch (i)
                {
                    case 1:
                        shooting = randomSkill.Next(1, 101);
                        pace = randomSkill.Next(90, 101);
                        defence = randomSkill.Next(90, 101);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        shooting = randomSkill.Next(1, 101);
                        pace = randomSkill.Next(90, 101);
                        defence = randomSkill.Next(90, 101);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        shooting = randomSkill.Next(1, 101);
                        pace = randomSkill.Next(90, 101);
                        defence = randomSkill.Next(90, 101);
                        break;
                    case 9:
                    case 10:
                    case 11:
                    default:
                        shooting = randomSkill.Next(90, 101);
                        pace = randomSkill.Next(90, 101);
                        defence = randomSkill.Next(1, 101);
                        break;
                }

                //int Luck = randomSkill.Next(1, 101);
                Player player = new Player(i, pace, shooting, defence);
                team.AddPlayerToTeam(player);
            }
            return team;
        }
    }
}