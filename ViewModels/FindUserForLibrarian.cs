using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.ViewModels
{
    public class FindUserForLibrarian
    { 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public FindUserForLibrarian()
        {

        }
    }
}