using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.Models
{
    public class BookProperty
    {
        public int Id { get; set; }

        public int CompositionTypeId { get; set; }
        public CompositionType CompositionType { get; set; }

        public int UsingRulesId { get; set; }
        public UsingRules UsingRules { get; set; }

        public int LibraryFundId { get; set; }
        public LibraryFund LibraryFund { get; set; }

        public string BookName { get; set; }
        public string Autor { get; set; }
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}