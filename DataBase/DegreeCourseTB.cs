using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThesisLibrary.DataBase
{
    public class DegreeCourseTB
    {
        DBMethods dbMethods;
        DummyData dd;
        public void CreateDegreeCourse()
        {
            dbMethods = new DBMethods();
            dd = new DummyData();
            string tableName = "DegreeCourse";
            string tableScheme = @"CREATE TABLE DegreeCourse(
                                [DegreeID] INTEGER PRIMARY KEY,                               
                                [DegreeName] TEXT NOT NULL,
                                [DepartmentID] INTEGER,
                                FOREIGN KEY(DepartmentID) REFERENCES Department(DepartmentID));";
            dbMethods.CreateTable(tableName, tableScheme);
            dd.AddDegreeCourses();
        }
    }
}
