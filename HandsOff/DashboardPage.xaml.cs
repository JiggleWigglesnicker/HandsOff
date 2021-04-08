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

        /// <summary>
        /// Navigates to the TeamCreatorPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamCreator_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TeamCreator));
        }

        /// <summary>
        /// Navigates to the MatchMakerPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatchMaker_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MatchMaker));
        }

        /// <summary>
        /// Navigates to the SimulationPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Simulation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SimulationPage));
        }

        /// <summary>
        /// Invokes when navigated to the dashboard page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
