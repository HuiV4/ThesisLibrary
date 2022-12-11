namespace ThesisLibrary.DataBase
{
    public class StudentTB
    {
        DBMethods dbMethods;
        /// <summary>
        /// This methode is called on startup if the database does not exist
        /// </summary>
        public void CreateStudent()
        {
            dbMethods = new();
            string tableName = "Student";
            string tableScheme = @"CREATE TABLE Student(
                                [StudentID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,                               
                                [UserID] INTEGER NOT NULL,
                                [DegreeName] TEXT NOT NULL,
                                FOREIGN KEY(DegreeName) REFERENCES DegreeCourse(DegreeName),
                                FOREIGN KEY(UserID) REFERENCES Users(UserID));";
            dbMethods.CreateTable(tableName, tableScheme);
        }
    }
}
