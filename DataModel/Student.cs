using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisLibrary.DataModel
{
    public class Student : Users
    {
        public int StudentID { get; set; }
        public string DegreeName { get; set; }
        public List<Users> LoadStudents()
        {
            List<Users> students = new List<Users>();
            int classID = 0;

            students = LoadUsers(students, classID);
            return students;
        }
    }
}
