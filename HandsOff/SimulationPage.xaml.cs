using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HandsOff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SimulationPage : Page
    {
        public SimulationPage()
        {
            this.InitializeComponent();
            Scores scores = new Scores();
            Scoresource.ItemsSource = scores;

            foreach (var scoreobj in DataAccess.GetData())
            {
                if (scores.Any(p => p == scoreobj))
                {
                    return;
                }
                scores.Add(scoreobj);
                // Dit moet nog gecheckt worden
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Dashboard));
        }
    }
}
