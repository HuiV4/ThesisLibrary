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
        UserDB uDB = new UserDB();
        public App()
        {
            tDB.CreateDatabaseAndTable();
            uDB.CreateDatabaseAndTable();
        }
    }
}
