using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace ThesisLibrary.DataBase
{
    public class ThesisDB
    {
        SQLiteConnection con;
        SQLiteCommand cmd;

        /// <summary>
        /// This methode is called on startup if the database does not exist
        /// </summary>
        public void CreateDatabaseAndTable()
        {
            try
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + @"\ThesisDB.sqlite"))
                {
                    string sql = @"CREATE TABLE Thesis(
                               [ThesisID] INTEGER PRIMARY KEY AUTOINCREMENT,
                               [Status] INTEGER NOT NULL DEFAULT 0,
                               [Title] TEXT NOT NULL,
                               [Abstract] TEXT NOT NULL,
                               [Startdate] DATE,
                               [SubmissionDate] DATE,
                               [Keywords] TEXT NOT NULL,
                               [Privacy] INTEGER NOT NULL,
                               [ThesisType] INTIGER NO NULL,
                               [StudentID] INTEGER,
                               [ProfessorID] INTEGER,
                               FOREIGN KEY(StudentID) REFERENCES Student(StudentID)
                               FOREIGN KEY(ProfessorID) REFERENCES Professor(ProfessorID));";
                    using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
                    {
                        con.Open();
                        cmd = new SQLiteCommand(sql, con);
                        cmd.ExecuteNonQuery();                        
                    }
                }
            }
            catch (Exception ex)
            {
                //Fehlermeldung ausgeben
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Adds an instance of thesis into the thesis table, when the student starts a request!
        /// </summary>
        /// <param name="thesisTitle"></param>
        /// <param name="thesisAbstract"></param>
        /// <param name="keywords"></param>
        /// <param name="studentID"></param>
        /// <param name="professorID"></param>
        /// <param name="thesisType">Indicates if thesis is bachelor or master thesis</param>
        /// <param name="privacy">Indicates if the  data is allowed to be downloaded</param>
        /// <param name="status">Indicates the current status of the thesis (see Enums)</param>
        public void AddThesisData(string thesisTitle, string thesisAbstract, string[] keywords, int studentID, int professorID, int thesisType, int privacy, int status = 0)
        {
            string keywordsString = "";
            foreach (var keyword in keywords)
            {
                keywordsString += $"{keyword};";
            }
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"insert into Thesis(Status, Title, Abstract, Keywords, Privacy, ThesisType, StudentID, ProfessorID) 
                                            values ('" + status + "','" + thesisTitle + "','" + thesisAbstract + "','" + keywordsString + "','" + privacy + "','" + thesisType + "','" + studentID + "','" + professorID + "')";
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
        /// Data will be updated or will be filled in if missing. Happens from the ThesisLookUpReq window 
        /// </summary>
        /// <param name="thesisID"></param>
        /// <param name="selectedStartDate"></param>
        /// <param name="selectedSubmitDate"></param>
        /// <param name="status">Indicates the current status of the thesis (see Enums)</param>
        public void UpdateThesisData(int thesisID, string selectedStartDate, string selectedSubmitDate, int status)
        {
            try
            {
                using (con = new SQLiteConnection($@"Data Source=ThesisDB.sqlite;Version=3;"))
                {
                    con.Open();
                    using (cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @$"UPDATE Thesis
                                            SET Startdate = '{selectedStartDate}', SubmissionDate = '{selectedSubmitDate}', Status = {status}
                                            WHERE Thesis.ID = '{thesisID}'";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
