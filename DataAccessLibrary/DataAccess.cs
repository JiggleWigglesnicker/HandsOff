using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
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

        //TODO ADD ALL FIELDS
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.db");
            using (SqliteConnection db =
                new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Teamname1 from Scores", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}