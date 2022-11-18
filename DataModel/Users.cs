using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ThesisLibrary.DataModel
{
    public class Users
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int UserClass { get; set; }
        public bool ParameterCheck(string firstName, string surName, string eMail, string password, ComboBox userClass)
        {
            if (firstName == "" || surName == "" || eMail == "" || password.Length < 8 || userClass.SelectedItem == null)
            {
                string msg = "Sie haben nicht alle Felder ausgefüllt!\nBitte beachten sie, dass Passwörter mind. 8 Zeichen lang sein müssen!";
                MessageBox.Show(msg, "Eingabe überprüfen", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!eMail.Contains("hs-flensburg.de" ))
            {
                string msg = "Diese Domäne wird von der Hochschule nicht unterstützt!\nBitte überprüfen sie die Mailadresse";
                MessageBox.Show(msg, "E-Mail überprüfen", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        public List<Users> LoadUsers(List<Users> userType, int classID)
        {
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                string selectSQL = $@"SELECT * FROM Users WHERE UserClass='{classID}'";
                using (cmd = new SQLiteCommand(selectSQL, con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Users users = new()
                            {
                                FirstName = dr[1].ToString(),
                                LastName = dr[2].ToString(),
                                EMail = dr[3].ToString(),
                                Password = dr[4].ToString(),
                                UserClass = int.Parse(dr[5].ToString())
                            };
                            userType.Add(users);
                        }
                    }
                }
            }
            return userType;
        }
    }
}
