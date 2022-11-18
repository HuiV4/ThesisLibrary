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
                con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;");
                con.Open();
                cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Users';", con);

                var result = cmd.ExecuteReader();
                
                if (!result.HasRows)
                {
                    string sql = @"CREATE TABLE Users(
                                [UserID] INTEGER PRIMARY KEY AUTOINCREMENT,
                                [EMail] TEXT,
                                [UserClass] INTEGER,
                                [Firstname] TEXT,
                                [Surname] TEXT);";
                    //con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;");
                    //con.Open();
                    cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();                    
                    con.Close();
                }
                result.Close();
            }
            catch (Exception ex)
            {
                //Fehlermeldung ausgeben
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddUserData(string firstName, string surName, string eMail, int userClass)
        {
            try
            {
                con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;");
                cmd = new SQLiteCommand();
                cmd.CommandText = "insert into Users(EMail, UserClass, FirstName, Surname) values ('" + eMail + "','" + userClass + "','" + firstName + "','" + surName + "')";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); // Daten können noch dppelt gespeichert werden (wegen fortlaufender ID)
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
