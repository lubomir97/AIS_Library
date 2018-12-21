using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models.Users;

namespace AIS_Library.Models
{
    public class Abonement
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}