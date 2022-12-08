namespace ThesisLibrary.DataBase
{
    public class DepartmentTB
    {
        DBMethods dbMethods;
        DummyData dd;
        public void CreateDept()
        {
            dbMethods = new DBMethods();
            dd = new DummyData();
            string tableName = "Department";
            string tableScheme = @"CREATE TABLE Department(
                                [DepartmentID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,                               
                                [DepartmentName] TEXT NOT NULL UNIQUE);";
            dbMethods.CreateTable(tableName, tableScheme);
            dd.AddDepartment();
        }        
    }
}
