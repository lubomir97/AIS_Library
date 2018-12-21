using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models
{
    public class Issuance
    {
        public int Id { get; set; }
        public DateTime Issue_date { get; set; }
        public DateTime Term_date { get; set; }
    }
}