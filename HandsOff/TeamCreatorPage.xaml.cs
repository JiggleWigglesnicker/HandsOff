using HandsOff.Models;
using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
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
        readonly string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "FC MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "C# Masters", "UWP 4 Life", "FC Frenkie", "VV Baptist", "James Blunt's Boys", "LT'jes Rozenwater", "FC Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood", "RoodWit", "FC Schoonebeek", "De Sonurs", "De Multithreaders", "VV Schoonoord", "VV Veendal", "P.H. Omtzigt", "Functie Elders"};
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
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 18,
                        Foreground = new SolidColorBrush(Colors.White)
                    };
                    if (i == 1)
                    {
                        playerLabel.Text = "GK";
                    }
                    if (i == 2)
                    {
                        playerLabel.Text = "LB";
                    }
                    if (i == 3 || i == 4)
                    {
                        playerLabel.Text = "CB";
                    }
                    if (i == 5)
                    {
                        playerLabel.Text = "RB";
                    }
                    if (i >= 6 && i <= 9)
                    {
                        playerLabel.Text = "CM";
                    }
                    if (i == 10 || i == 11)
                    {
                        playerLabel.Text = "ST";
                    }
                    
                    TextBlock speedLabel = new TextBlock
                    {
                        Text = "Speed",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 14,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 5, 0, 0)
                    };

                    TextBlock attackLabel = new TextBlock
                    {
                        Text = "Attack",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 14,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 2, 0, 0)
                    };

                    TextBlock defenceLabel = new TextBlock
                    {
                        Text = "Defence",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 14,
                        Foreground = new SolidColorBrush(Colors.White),
                        Margin = new Thickness(15, 2, 0, 0)
                    };

                    TextBox speedTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 12,
                        Height = 35,
                        Width = 50
                    };

                    TextBox attackTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 12,
                        Height = 35,
                        Width = 50
                    };

                    TextBox defenceTextBox = new TextBox
                    {
                        Text = "55",
                        Background = new SolidColorBrush(Colors.Wheat),
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 12,
                        Height = 35,
                        Width = 50
                    };

                    grid.Children.Add(stackPanel);
                    //scrollView.Content = stackPanel;
                    stackPanel.Children.Add(playerLabel);
                    stackPanel.Children.Add(speedLabel);
                    stackPanel.Children.Add(speedTextBox);
                    stackPanel.Children.Add(attackLabel);
                    stackPanel.Children.Add(attackTextBox);
                    stackPanel.Children.Add(defenceLabel);
                    stackPanel.Children.Add(defenceTextBox);

                    if (i <= 1)
                    {
                        Grid.SetColumn(stackPanel, x + 2);
                        Grid.SetRow(stackPanel, 3);

                        x++;

                        if (x == 1)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 1 && i <= 5)
                    {
                        Grid.SetColumn(stackPanel, x +1);
                        Grid.SetRow(stackPanel, 2);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 5 && i <= 9)
                    {
                        Grid.SetColumn(stackPanel, x +1);
                        Grid.SetRow(stackPanel, 1);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 9)
                    {
                        Grid.SetColumn(stackPanel, x +2);
                        Grid.SetRow(stackPanel, 0);

                        x++;

                        if (x == 2)
                        {
                            x = 0;
                        }
                    }
                });
            }
        }

        private async void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            App.Teams.Add(CreateCustomTeam());
        }

        public Team CreateCustomTeam()
        {
            Team team = new Team();

            if (TeamNameBox.Text == "")
            {
                team.TeamName = "Unnamed Team";
            }
            else
            {
                team.TeamName = TeamNameBox.Text;
            }

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

        private async void CreateRandomTeam_Click(object sender, RoutedEventArgs e)
        {
            Team RandomTeam = CreateTeam();

            RandomTeam.TeamName = Generate_TeamName();
            App.Teams.Add(RandomTeam);
        }

        public string Generate_TeamName()
        {
            string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "NAC Breda", "Herres", "GOAT", "Kamerbreed Tapijt", "SC Ria Valk", "VV De Derde Helft", "Geen centen maar spullen", "FC Stacksjouwers", "Up the irons!", "Fc Gullit", "Juventus", "Galatasaray", "Fc Vriescheloo", "Onstwedderboys", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "Fc MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "C# Masters", "UWP 4 Life", "Fc Frenkie", "VV Baptist", "James Blunt's Boys", "Ltjes Rozenwater", "Fc Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood", "FC Schoonebeek", "De Sonurs", "De Multithreaders" };
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