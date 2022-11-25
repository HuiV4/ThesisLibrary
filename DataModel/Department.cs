using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisLibrary.DataModel
{
    public class Department
    {
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public string DeptName { get; set; }
        public List<Department> LoadDepartments()
        {
            List<Department> deptList = new();
            using (con = new SQLiteConnection("Data Source=ThesisDB.sqlite;Version=3;"))
            {                
                con.Open();
                string selectSQL = $@"SELECT DepartmentName FROM Department";
                using (cmd = new SQLiteCommand(selectSQL, con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Department dept = new()
                            {
                                DeptName = dr[0].ToString()
                            };
                            deptList.Add(dept);
                        }
                    }
                }
            }
            return deptList;
        }
        public override string ToString()
        {
            return DeptName;
        }
    }
}
