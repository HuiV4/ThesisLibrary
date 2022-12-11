using System;
using System.Data.SQLite;
using System.Windows;

namespace ThesisLibrary.DataBase
{
    public class DBMethods
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        /// <summary>
        /// Each table creation uses this methode, if database does not exist
        /// </summary>
        /// <param name="tableName">The name which the table will get on creation</param>
        /// <param name="tableScheme">The SQL command for the parameters and constraints</param>
        public void CreateTable(string tableName, string tableScheme)
        {
            try
            {
                using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", con))
                    {

                        using (var result = cmd.ExecuteReader())
                        {
                            if (!result.HasRows)
                            {
                                cmd = new SQLiteCommand(tableScheme, con);
                                cmd.ExecuteNonQuery();
                            }
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
    }
}
