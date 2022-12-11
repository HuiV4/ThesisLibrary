namespace ThesisLibrary.DataBase
{
    public class DegreeCourseTB
    {
        DBMethods dbMethods;
        DummyData dd;
        /// <summary>
        /// This methode is called on startup if the database does not exist
        /// </summary>
        public void CreateDegreeCourse()
        {
            dbMethods = new DBMethods();
            dd = new DummyData();
            string tableName = "DegreeCourse";
            string tableScheme = @"CREATE TABLE DegreeCourse(
                                [DegreeID] INTEGER PRIMARY KEY,                               
                                [DegreeName] TEXT NOT NULL UNIQUE,
                                [DepartmentID] INTEGER,
                                FOREIGN KEY(DepartmentID) REFERENCES Department(DepartmentID));";
            dbMethods.CreateTable(tableName, tableScheme);
            dd.AddDegreeCourses();
        }
    }
}
