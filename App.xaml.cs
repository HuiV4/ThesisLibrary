using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ThesisLibrary.DataBase;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ThesisDB tDB = new();
        UserTB uTB = new();
        DepartmentTB dTB = new();
        DegreeCourseTB dCTB = new();
        ProfessorTB pTB = new();
        StudentTB sTB = new();

        public App()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\ThesisDB.sqlite"))
            {
                tDB.CreateDatabaseAndTable();
                uTB.CreateUsers();
                dTB.CreateDept();
                dCTB.CreateDegreeCourse();
                pTB.CreateProfessor();
                sTB.CreateStudent();
            }
        }
    }
}
