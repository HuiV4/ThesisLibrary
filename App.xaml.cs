using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        Database tDB = new();
        UserTB uTB = new();
        DepartmentTB dTB = new();
        DegreeCourseTB dCTB = new();
        public App()
        {
            tDB.CreateDatabaseAndTable();
            uTB.CreateTable();
            dTB.CreateTable();
            dCTB.CreateTable();
        }
    }
}
