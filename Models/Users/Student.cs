using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models.Users
{
    public class Student
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public int Course { get; set; }
        public string Group { get; set; }
    }
}