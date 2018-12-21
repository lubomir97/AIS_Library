using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_Library.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LibraryId { get; set; }

        public string Librarian { get; set; }
       
    }
}