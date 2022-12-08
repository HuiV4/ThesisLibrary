namespace ThesisLibrary.DataBase
{
    public class ProfessorTB
    {
        DBMethods dbMethods;

        public void CreateProfessor()
        {
            dbMethods = new();
            string tableName = "Professor";
            string tableScheme = @"CREATE TABLE Professor(
                                [ProfessorID] INTEGER PRIMARY KEY AUTOINCREMENT,                               
                                [UserID] INTEGER NOT NULL,                                
                                [DepartmentName] TEXT NOT NULL,
                                FOREIGN KEY(DepartmentName) REFERENCES Department(DepartmentName),
                                FOREIGN KEY(UserID) REFERENCES Users(UserID));";
            dbMethods.CreateTable(tableName, tableScheme);
        }
    }
}
