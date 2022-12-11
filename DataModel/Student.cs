using System.Collections.Generic;

namespace ThesisLibrary.DataModel
{
    public class Student : Users
    {
        public int StudentID { get; set; }
        public string DegreeName { get; set; }
        /// <summary>
        /// Loads the list of all students
        /// </summary>
        /// <returns></returns>
        public List<Users> LoadStudents()
        {
            List<Users> students = new List<Users>();
            int classID = 0;

            students = LoadUsers(students, classID);
            return students;
        }
    }
}
