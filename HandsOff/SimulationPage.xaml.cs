using DataAccessLibrary;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SimulationPage : Page
    {
        // Creates list items from past match results, and displays them.
        public SimulationPage()
        {
            InitializeComponent();
            Scores Scores = new Scores();
            Scoresource.ItemsSource = Scores;

            _ = Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    foreach (Score Scoreobj in DataAccess.GetData())
                    {
                        if (Scores.Any(p => p == Scoreobj))
                        {
                            return;
                        }
                        Scores.Add(Scoreobj);
                        // Dit moet nog gecheckt worden
                    }
                });
        }


        /// <summary>
        /// Navigates back to the previous Frame (Page).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Dashboard));
        }
    }
}
