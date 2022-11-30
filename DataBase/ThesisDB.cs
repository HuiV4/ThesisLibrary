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
    public class ThesisDB
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        /// <summary>
        /// Diese Methode erstellt die Datenbank, wenn noch keine vorhanden ist.
        /// Wenn die DB bereit vorhanden ist, wird eine Verbindung hergestellt
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

    }
}
