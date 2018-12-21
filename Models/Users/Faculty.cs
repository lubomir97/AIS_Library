using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models.Users
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UnivertityId { get; set; }
        public University University { get; set; }
    }
}