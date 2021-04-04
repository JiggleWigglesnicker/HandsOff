using System.Diagnostics;
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
                scores.Add(scoreobj);
                // Score score = new Score(scoreobj[0].ToString(), scoreobj[1], scoreobj[2], scoreobj[3]);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}
