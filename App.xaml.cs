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
        Database tDB = new Database();
        UserTB uTB = new UserTB();
        public App()
        {
            tDB.CreateDatabaseAndTable();
            uTB.CreateTable();
        }
    }
}
