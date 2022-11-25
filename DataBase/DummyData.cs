using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisLibrary.DataBase
{
    public class DummyData
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public void AddDegreeCourses()
        {
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {
                    using (StreamReader sr = new StreamReader(@"DataBase\Studiengänge.txt"))
                    {
                        var cols = sr.ReadLine().Split(new char[] { ';' });
                        if (cols.Length != 2)
                            throw new ArgumentException("Falsche Datei");
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            cols = line.Split(new char[] { ';' });

                            cmd.CommandText = @"insert into DegreeCourse(DegreeName, DepartmentID) 
                                            values ('" + cols[0] + "','" + cols[1] + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public void AddDepartment()
        {
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                using (cmd = new SQLiteCommand(con))
                {
                    using (StreamReader sr = new StreamReader(@"DataBase\Fachbereiche.txt"))
                    {
                        var cols = sr.ReadLine().Split(new char[] { ';' });
                        if (cols.Length != 2)
                            throw new ArgumentException("Falsche Datei");
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            cols = line.Split(new char[] { ';' });

                            cmd.CommandText = @"insert into Department(DepartmentName)
                                                values ('" + cols[1] + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}

