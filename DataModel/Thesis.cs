using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ThesisLibrary.DataModel
{

    public class Thesis
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public List<string> list { get; set; }
        public int ThesisID { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime SubmissonDate { get; set; }
        public string[] Keywords { get; set; }
        public string ProfessorFirstName { get; set; }
        public string ProfessorLastName { get; set; }
        public int ProfessorID { get; set; }
        public string DepartmentName { get; set; }
        public int StudentID { get; set; }
        public string DegreeName { get; set; }
        public int Privacy { get; set; }
        public int ThesisType { get; set; }

        /// <summary>
        /// Loads all theses that are avaiable in the thesis table of the database
        /// </summary>
        /// <returns>A list of all theses</returns>
        public List<Thesis> LoadThesisList()
        {
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {
                List<Thesis> thesisList = new List<Thesis>();
                list = new List<string>();

                con.Open();
                string selectSQL = $@"SELECT t.ID, t.Status, t.Title, t.Abstract, t.Startdate,
                                      t.SubmissionDate, t.Keywords, t.Privacy, t.ThesisType,
                                      u.Firstname, u.Surname, p.ProfessorID, p.DepartmentName,
                                      s.StudentID, s.DegreeName
                                      FROM Thesis t
                                      JOIN Professor p
                                      ON p.ProfessorID = t.ProfessorID
                                      JOIN Users u
                                      ON p.UserID = u.UserID
                                      JOIN Student s
                                      ON s.StudentID = t.StudentID";
                using (cmd = new SQLiteCommand(selectSQL, con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read() != false)
                        {
                            string keywordsString = dr[6].ToString();
                            string[] keywords = keywordsString.Split(',');
                            foreach (string keyword in keywords)
                            {
                                list.Add(keyword);
                            }
                            string[] keywordArray = list.ToArray();

                            
                            Thesis thesis = new Thesis()
                            {
                                ThesisID = int.Parse(dr[0].ToString()),
                                Status = int.Parse(dr[1].ToString()),
                                Title = dr[2].ToString(),
                                Abstract = dr[3].ToString(),
                                Keywords = keywordArray,
                                Privacy = int.Parse(dr[7].ToString()),
                                ThesisType = int.Parse(dr[8].ToString()),
                                ProfessorFirstName = dr[9].ToString(),
                                ProfessorLastName = dr[10].ToString(),
                                ProfessorID = int.Parse(dr[11].ToString()),
                                DepartmentName = dr[12].ToString(),
                                StudentID = int.Parse(dr[13].ToString()),
                                DegreeName = dr[14].ToString()
                            };
                            thesisList.Add(thesis);

                        }
                    }
                }
                return thesisList;
            }
        }
    }
}
