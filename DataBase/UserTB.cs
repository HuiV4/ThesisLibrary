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
        DBMethods dbMethods;

        /// <summary>
        /// Diese Methode erstellt die Datenbank, wenn noch keine vorhanden ist.
        /// Wenn die DB bereit vorhanden ist, wird eine Verbindung hergestellt
        /// </summary>
        public void CreateUsers()
        {
            dbMethods = new();
            string tableName = "Users";
            string tableScheme = @"CREATE TABLE Users(
                                [UserID] INTEGER PRIMARY KEY AUTOINCREMENT,
                                [Firstname] TEXT NOT NULL,
                                [Surname] TEXT NOT NULL,
                                [EMail] TEXT NOT NULL,
                                [Password] TEXT NOT NULL,
                                [UserClass] INTEGER);";

            dbMethods.CreateTable(tableName, tableScheme);
        }
        public void AddUserData(string firstName, string surName, string eMail, string password, int userClass)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {                        
                        cmd.CommandText = @"insert into Users(FirstName, Surname, EMail, Password, UserClass) 
                                            values ('" + firstName + "','" + surName + "','" + eMail + "','" + password + "','" + userClass + "')";
                        cmd.ExecuteNonQuery(); // Daten können noch doppelt gespeichert werden (wegen fortlaufender ID)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddProfessor(int userID, int userClass, string departmentName)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"insert into Professor(UserID, UserClass, DepartmentName)
                                values ('" + userID + "','" + userClass + "', '" + departmentName + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddStudent(int userID, int userClass, string degreeName)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"insert into Student(UserID, UserClass, DegreeName)
                                values ('" + userID + "','" + userClass + "', '" + degreeName + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int GetUserID(string firstName, string surName)
        {
            using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {                    
                    cmd.CommandText = $@"SELECT UserID 
                                 FROM Users 
                                 WHERE Firstname LIKE '{firstName}' AND Surname LIKE '{surName}'";
                    object userID = cmd.ExecuteScalar();
                    return Convert.ToInt32(userID);
                }
            }
        }
    }
}
