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
        private readonly System.Random randomNumber = new System.Random();
        private string RandomTeamName;

        public TeamCreator()
        {
            InitializeComponent();
            TeamPageUIAsync();
        }

        /// <summary>
        /// Multithreads the CreateTeamCreatorUI() method.
        /// </summary>
        public async void TeamPageUIAsync()
        {
            await Task.Run(() =>
            {
                CreateTeamCreatorUI();
            });
        }

        /// <summary>
        /// Creates GUI elements to display players of team, with attributes fields.
        /// </summary>
        public async void CreateTeamCreatorUI()
        {
            int x = 0;
            Grid grid = TeamGrid;
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
                    stackPanel.Children.Add(playerLabel);
                    stackPanel.Children.Add(speedLabel);
                    stackPanel.Children.Add(speedTextBox);
                    stackPanel.Children.Add(attackLabel);
                    stackPanel.Children.Add(attackTextBox);
                    stackPanel.Children.Add(defenceLabel);
                    stackPanel.Children.Add(defenceTextBox);

                    // Positions the players in the correct grid row.
                    if (i <= 1)
                    {
                        Grid.SetColumn(stackPanel, x + 2);
                        Grid.SetColumnSpan(stackPanel, 2);
                        Grid.SetRow(stackPanel, 3);

                        x++;

                        if (x == 1)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 1 && i <= 5)
                    {
                        Grid.SetColumn(stackPanel, x + 1);
                        Grid.SetRow(stackPanel, 2);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 5 && i <= 9)
                    {
                        Grid.SetColumn(stackPanel, x + 1);
                        Grid.SetRow(stackPanel, 1);

                        x++;

                        if (x == 4)
                        {
                            x = 0;
                        }
                    }
                    else if (i > 9)
                    {
                        Grid.SetColumn(stackPanel, x + 2);
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

        /// <summary>
        /// When invoked creates a new custom-made team on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            if (TeamNameBox.Text == "")
            {
                // Show message dialog when no team name has been entered
                MessageDialog showDialog = new MessageDialog("Please enter a team name.");
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
            else
            {
                App.Teams.Add(CreateCustomTeam());

                // Show message dialog when a custom team has been created
                MessageDialog showDialog = new MessageDialog("Team " + TeamNameBox.Text + " has been created!");
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
        }


        /// <summary>
        /// Adds players to a team based on fields in the GUI.
        /// </summary>
        /// <returns></returns>
        public Team CreateCustomTeam()
        {
            Team team = new Team();
            team.TeamName = TeamNameBox.Text;

            for (int i = 1; i < 12; i++)
            {
                StackPanel stackpanel = (StackPanel)FindName("stackpanel" + i);
                TextBox textBox1 = (TextBox)stackpanel.Children[2];
                TextBox textBox2 = (TextBox)stackpanel.Children[4];
                TextBox textBox5 = (TextBox)stackpanel.Children[6];
                int Speed = (int)long.Parse(textBox1.Text);
                int Attack = (int)long.Parse(textBox2.Text);
                int Defense = (int)long.Parse(textBox5.Text);

                Player player = new Player(i, Attack, Speed, Defense);
                team.AddPlayerToTeam(player);
            }
            return team;
        }

        /// <summary>
        /// Generates a new random team with random properties on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateRandomTeam_Click(object sender, RoutedEventArgs e)
        {
            Team RandomTeam = CreateTeam();

            RandomTeam.TeamName = Generate_TeamName();
            App.Teams.Add(RandomTeam);

            // Show message dialog when random team has been generated.
            MessageDialog showDialog = new MessageDialog("Random team has been generated with the name : " + RandomTeam.TeamName);
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

        /// <summary>
        /// Selects a random team name from a list, to be used for naming a random team.
        /// </summary>
        /// <returns></returns>
        public string Generate_TeamName()
        {
            string[] TeamNames = { "Ajax", "Feyenoord", "PSV", "FC Emmen", "NAC Breda", "Herres", "GOAT", "Kamerbreed Tapijt", "SC Ria Valk", "VV De Derde Helft", "Geen centen maar spullen", "FC Stacksjouwers", "Up the irons!", "FC Gullit", "Juventus", "Galatasaray", "FC Vriescheloo", "Onstwedderboys", "Manchester United", "Chelsea", "AZ", "Mongo Thierry", "FC MusicMixer", "LTC Assen 6", "Mannen van het zesde", "FC Barcelona", "Tiri Boys", "VVJ Judas", "C# Masters", "UWP 4 Life", "FC Frenkie", "VV Baptist", "James Blunt's Boys", "Ltjes Rozenwater", "FC Gaan met Die Banaan", "Oranje", "Blauw", "Rood Wit", "Jong Ajax", "GroenGeel", "OranjeRood", "FC Schoonebeek", "De Sonurs", "De Multithreaders" };
            RandomTeamName = TeamNames[randomNumber.Next(0, TeamNames.Length - 1)];

            return RandomTeamName;
        }

        /// <summary>
        /// Creates new random team with random properties.
        /// </summary>
        /// <returns></returns>
        public Team CreateTeam()
        {
            System.Random randomSkill = new System.Random();

            Team team = new Team();
            int Attack;
            int Speed;
            int Defence;

            for (int i = 1; i < 12; i++)
            {
                switch (i)
                {
                    case 1:
                        Attack = randomSkill.Next(1, 101);
                        Speed = randomSkill.Next(1, 101);
                        Defence = randomSkill.Next(1, 101);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Attack = randomSkill.Next(1, 101);
                        Speed = randomSkill.Next(1, 101);
                        Defence = randomSkill.Next(1, 101);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        Attack = randomSkill.Next(1, 101);
                        Speed = randomSkill.Next(1, 101);
                        Defence = randomSkill.Next(1, 101);
                        break;
                    case 9:
                    case 10:
                    case 11:
                    default:
                        Attack = randomSkill.Next(1, 101);
                        Speed = randomSkill.Next(1, 101);
                        Defence = randomSkill.Next(1, 101);
                        break;
                }

                Player player = new Player(i, Attack, Speed, Defence);
                team.AddPlayerToTeam(player);
            }
            return team;
        }

        /// <summary>
        /// Navigates back to previous page (Frame).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}