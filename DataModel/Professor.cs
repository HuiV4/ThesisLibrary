﻿using System.Collections.Generic;

namespace ThesisLibrary.DataModel
{
    public class Professor : Users
    {
        public int ProfessorID { get; set; }
        public string DepartmentName { get; set; }
        public List<Users> LoadProfessors()
        {
            List<Users> professors = new();
            int classID = 1;

            professors = LoadUsers(professors, classID);
            return professors;
        }
    }
}
