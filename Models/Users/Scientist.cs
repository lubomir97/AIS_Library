using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models.Users
{
    public class Scientist
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Topic { get; set; }
    }
}