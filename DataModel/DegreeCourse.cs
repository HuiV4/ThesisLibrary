using System.Collections.Generic;
using System.Data.SQLite;

namespace ThesisLibrary.DataModel
{
    public class DegreeCourse
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public string DegreeName { get; set; }
        /// <summary>
        /// Loads all DegreeCourses from the database and initializes them
        /// </summary>
        /// <returns></returns>
        public List<DegreeCourse> LoadDegreeCourses()
        {
            List<DegreeCourse> degreeList = new();
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {
                con.Open();
                string selectSQL = $@"SELECT DegreeName FROM DegreeCourse";
                using (cmd = new SQLiteCommand(selectSQL, con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DegreeCourse degree = new()
                            {
                                DegreeName = dr[0].ToString()
                            };
                            degreeList.Add(degree);
                        }
                    }
                }
            }
            return degreeList;
        }
        public override string ToString()
        {
            return DegreeName;
        }
    }
}
