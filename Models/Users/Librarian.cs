using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models.Users
{
    public class Librarian
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int ReadingRoomId { get; set; }
    }
}