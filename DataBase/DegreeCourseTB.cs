using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThesisLibrary.DataBase
{
    public class DegreeCourseTB
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public void CreateTable()
        {
            try
            {
                using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='DegreeCourse';", con);

                    using (var result = cmd.ExecuteReader())
                    {
                        if (!result.HasRows)
                        {
                            string sql = @"CREATE TABLE DegreeCourse(
                                [DegreeID] INTEGER PRIMARY KEY,                               
                                [DegreeName] TEXT NOT NULL,
                                [DepartmentID] INTEGER,
                                FOREIGN KEY(DepartmentID) REFERENCES Department(DepartmentID));";
                            //[DepartementID] REFERENCE[Departement](DepartementID)
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
    }
}
