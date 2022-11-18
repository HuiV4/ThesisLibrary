using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisLibrary.DataModel
{
    public class Admin : Users
    {
        public List<Users> LoadAdmins()
        {
            List<Users> admins = new List<Users>();
            int classID = 2;

            admins = LoadUsers(admins, classID);
            return admins;

        }
    }
}
