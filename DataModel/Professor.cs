using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisLibrary.DataModel
{
    public class Professor : Users
    {
        public List<Users> LoadProfessors()
        {
            List<Users> professors = new();
            int classID = 1;

            professors = LoadUsers(professors, classID);
            return professors;
        }
    }
}
