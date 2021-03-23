using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Dashboard : Page
    {
        public Dashboard()
        {
            this.InitializeComponent();
        }

        private void TeamCreator_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamCreator));
        }

        private void MatchMaker_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MatchMaker));
        }

        private void Simulation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SimulationPage));
        }

    }
}
