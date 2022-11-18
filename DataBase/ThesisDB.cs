using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThesisLibrary.DataBase
{
    public class Database
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        /// <summary>
        /// Diese Methode erstellt die Datenbank, wenn noch keine vorhanden ist.
        /// Wenn die DB bereit vorhanden ist, wird eine Verbindung hergestellt
        /// </summary>
        public void CreateDatabaseAndTable()
        {
            try
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + @"\ThesisDB.sqlite"))
                {
                    string sql = @"CREATE TABLE Thesis(
                               [ID] INTEGER PRIMARY KEY AUTOINCREMENT,
                               [Status] INTEGER NOT NULL DEFAULT 0,
                               [Title] TEXT NOT NULL,
                               [Abstract] TEXT,
                               [Startdate] DATE,
                               [SubmissionDate] DATE,
                               [Keywords] TEXT,
                               [StudentID] INTEGER,
                               [LecturerID] INTEGER,
                               [SecondLecturerID] INTEGER);";
                    con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;");
                    con.Open();
                    cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                //else
                //{
                //    con = new SQLiteConnection($@"Data Source={Directory.GetCurrentDirectory()}\ThesisDB.sqlite;Version=3;");
                //}
            }
            catch (Exception ex)
            {
                //Fehlermeldung ausgeben
                MessageBox.Show(ex.Message);
            }
        }

    }
}
