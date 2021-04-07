using HandsOff.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page
    {
        private Team Team { get; set; }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void TeamCreator_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TeamCreator));
        }

        private void MatchMaker_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MatchMaker));
        }

        private void Simulation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SimulationPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                Team = (Team)e.Parameter;
            }
        }
    }
}
