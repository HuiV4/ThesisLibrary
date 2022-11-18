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
    public class UserTB
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        /// <summary>
        /// Diese Methode erstellt die Datenbank, wenn noch keine vorhanden ist.
        /// Wenn die DB bereit vorhanden ist, wird eine Verbindung hergestellt
        /// </summary>
        public void CreateTable()
        {
            try
            {
                using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Users';", con);

                    using (var result = cmd.ExecuteReader())
                    {
                        if (!result.HasRows)
                        {
                            string sql = @"CREATE TABLE Users(
                                [UserID] INTEGER PRIMARY KEY AUTOINCREMENT,
                                [Firstname] TEXT NOT NULL,
                                [Surname] TEXT NOT NULL,
                                [EMail] TEXT NOT NULL,
                                [Password] TEXT NOT NULL,
                                [UserClass] INTEGER);";
                            cmd = new SQLiteCommand(sql, con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Fehlermeldung ausgeben
                MessageBox.Show(ex.Message);
            }
        }
        public void AddUserData(string firstName, string surName, string eMail, string password, int userClass)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    cmd = new SQLiteCommand();
                    cmd.CommandText = "insert into Users(FirstName, Surname, EMail, Password, UserClass) values ('" + firstName + "','" + surName + "','" + eMail + "','" + password + "','" + userClass + "')";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery(); // Daten können noch doppelt gespeichert werden (wegen fortlaufender ID)
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
