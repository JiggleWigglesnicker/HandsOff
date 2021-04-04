using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        /// <summary>
        /// Initializes the database and creates one if not existing
        /// </summary>
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("database.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.db");
            using (SqliteConnection db =
                new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand =
                    "CREATE TABLE IF NOT EXISTS Scores " +
                    "(ID INTEGER NOT NULL UNIQUE, " +
                    "Teamname1 TEXT NOT NULL, " +
                    "Teamname2 TEXT NOT NULL, " +
                    "Teamscore1 INTEGER NOT NULL, " +
                    "Teamscore2 INTEGER NOT NULL, " +
                    "PRIMARY KEY(ID AUTOINCREMENT))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        /// <summary>
        /// Add scores to the database
        /// example code: DataAccess.AddScores("test22", "test2", 1, 2);
        /// </summary>
        /// <param name="team1"></param>
        /// <param name="team2"></param>
        /// <param name="score1"></param>
        /// <param name="score2"></param>
        public static void AddScores(string team1, string team2, int score1, int score2)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.db");
            using (SqliteConnection db =
                new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Scores VALUES (NULL, @team1, @team2, @score1, @score2);";
                insertCommand.Parameters.AddWithValue("@team1", team1);
                insertCommand.Parameters.AddWithValue("@team2", team2);
                insertCommand.Parameters.AddWithValue("@score1", score1);
                insertCommand.Parameters.AddWithValue("@score2", score2);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        /// <summary>
        /// Return scores from the database as list of objects in descending order
        /// Example code: DataAccess.GetData()[0][0] //This returns the first row and first field
        /// </summary>
        /// <param name="rows">Amount of rows to return, when 0 or nothing given return all rows</param>
        /// <returns></returns>
        public static List<object[]> GetData(int rows = 0)
        {
            List<object[]> entries = new List<object[]>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.db");
            using (SqliteConnection db =
                new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand;

                if (rows == 0)
                {
                    selectCommand = new SqliteCommand
                        ("SELECT Teamname1, Teamname2, Teamscore1, Teamscore2 from Scores ORDER BY ID DESC", db);
                }
                else
                {
                    selectCommand = new SqliteCommand
                        ("SELECT Teamname1, Teamname2, Teamscore1, Teamscore2 from Scores ORDER BY ID DESC LIMIT " + rows, db);
                }
                

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    object[] objs = new object[4];
                    query.GetValues(objs);
                    entries.Add(objs);
                }

                db.Close();
            }

            return entries;
        }
    }
}