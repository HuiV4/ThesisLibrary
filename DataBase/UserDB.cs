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
    public class UserDB
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
                if (!File.Exists(Directory.GetCurrentDirectory() + @"\UserDB.sqlite"))
                {
                    string sql = @"CREATE TABLE Users(
                                [UserID] INTEGER PRIMARY KEY AUTOINCREMENT,
                                [EMail] TEXT,
                                [UserClass] INTEGER,
                                [Firstname] TEXT,
                                [Surname] TEXT);";
                    con = new SQLiteConnection("Data Source=UserDB.sqlite;Version=3;");
                    con.Open();
                    cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    con = new SQLiteConnection($@"Data Source={Directory.GetCurrentDirectory()}\UserDB.sqlite;Version=3;");
                }
            }
            catch (Exception ex)
            {
                //Fehlermeldung ausgeben
                MessageBox.Show(ex.Message);
            }            
        }
        public void AddUserData(string firstName, string surName, string eMail, int userClass)
        {            
            string insertSQL = "INSERT INTO UserDB (EMail, UserClass, FirstName, Surname) VALUES ("+firstName+", "+surName+","+eMail+","+userClass+")";
            con = new SQLiteConnection("Data Source=UserDB.sqlite;Version=3;");
            con.Open();
            cmd = new SQLiteCommand(insertSQL, con);
            cmd.ExecuteNonQuery();
            con.Close();

            try
            {
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
