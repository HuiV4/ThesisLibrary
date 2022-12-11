using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ThesisLibrary.DataBase
{
    public class UserTB
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        DBMethods dbMethods;

        /// <summary>
        /// This methode is called on startup if the database does not exist
        /// </summary>
        public void CreateUsers()
        {
            dbMethods = new DBMethods();
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
        /// <summary>
        /// An instance of user will be added into the user table
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surName"></param>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <param name="userClass"></param>
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
        /// <summary>
        /// Foreach added user, an corresponding  Professor will be added, if the UserType equals 1
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="departmentName"></param>
        public void AddProfessor(int userID, string departmentName)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"insert into Professor(UserID, DepartmentName)
                                values ('" + userID + "','" + departmentName + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Foreach added user, an corresponding  Student will be added, if the UserType equals 0
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="departmentName"></param>
        public void AddStudent(int userID, string degreeName)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"insert into Student(UserID, DegreeName)
                                values ('" + userID + "','" + degreeName + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Login the UserID will be fetched, so that the current user can be authenticated
        /// </summary>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetUserID(string eMail, string password)
        {
            using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {                    
                    cmd.CommandText = $@"SELECT UserID 
                                 FROM Users 
                                 WHERE EMail = '{eMail}' AND Password = '{password}'";
                    object userID = cmd.ExecuteScalar();
                    return Convert.ToInt32(userID);
                }
            }
        }
        /// <summary>
        /// This methode gets the UserClass of the current user, to give permissions that are intendet for the UserClass
        /// </summary>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetUserClass(string eMail, string password)
        {
            using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = $@"SELECT UserClass 
                                 FROM Users 
                                 WHERE EMail = '{eMail}' AND Password = '{password}'";
                    object userID = cmd.ExecuteScalar();
                    return Convert.ToInt32(userID);
                }
            }
        }
        /// <summary>
        /// Checks if the User logging in is really existing
        /// </summary>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidUser(string eMail, string password)
        {
            using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = $@"SELECT UserID 
                                       FROM Users 
                                       WHERE EMail = '{eMail}' AND Password = '{password}'";
                    using (dr = cmd.ExecuteReader())
                    {
                        if(dr.Read() != true)
                            return false;
                        else
                        return true;
                    }
                }
            }
        }
        /// <summary>
        /// This method simply resets all inputs from the ModalAddUser Window
        /// </summary>
        /// <param name="t1"> Textbox userFirstName</param>
        /// <param name="t2"> Textbox userSurName</param>
        /// <param name="t3"> Textbox userEMail</param>
        /// <param name="p1"> PasswordBox password </param>
        /// <param name="p2"> PasswordBox passwordCheck </param>
        /// <param name="c1"> ComboBox userClass </param>
        /// <param name="c2"> ComboBox dynamicCombobox </param>
        public void ResetValues(TextBox t1, TextBox t2, TextBox t3, PasswordBox p1, PasswordBox p2, ComboBox c1, ComboBox c2)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            p1.Clear();
            p2.Clear();
            c1.SelectedItem = null;
            c2.SelectedItem = null;
        }
    }
}
