﻿using HandsOff.Models;
using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DataAccessLibrary;
using System.Collections.Generic;

namespace HandsOff
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static List<Team> teams = new List<Team>();

        //public static Team team1 { get; private set; }
        //public static Team team2 { get; private set; }
        //public static Team team3 { get; private set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            Team team1 = CreateTeam();
            team1.TeamName = "Example Team 1";
            teams.Add(team1);
            Team team2 = CreateTeam();
            team2.TeamName = "Example Team 2";
            teams.Add(team2);
            Team team3 = CreateTeam();
            team3.TeamName = "Example Team 3";
            teams.Add(team3);
            //Initialize the database at startup
            DataAccess.InitializeDatabase();

            // DataAccess.AddScores("test22", "test2", 1, 2);

            // Debug.Write(DataAccess.GetData()[0][1]);

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

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public static bool TryGoBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }

    }
}
