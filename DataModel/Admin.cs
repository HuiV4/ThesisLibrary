using System.Collections.Generic;

namespace ThesisLibrary.DataModel
{
    public class Admin : Users
    {
        /// <summary>
        /// Loads the list of all admins
        /// </summary>
        /// <returns></returns>
        public List<Users> LoadAdmins()
        {
            List<Users> admins = new List<Users>();
            int classID = 2;

            admins = LoadUsers(admins, classID);
            return admins;

        }
    }
}
