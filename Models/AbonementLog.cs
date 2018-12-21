using AIS_Library.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models
{
    public class AbonementLog
    {
        public int Id { get; set; }

        public int IssuanceId { get; set; }
        public Issuance Issuance { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookPropertyId { get; set; }
        public BookProperty BookProperty { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}