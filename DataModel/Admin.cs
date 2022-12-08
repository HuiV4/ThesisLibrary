using System.Collections.Generic;

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
