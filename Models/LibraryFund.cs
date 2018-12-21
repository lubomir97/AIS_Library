using System;

namespace AIS_Library.Models
{
    public class LibraryFund
    {
        public int Id { get; set; }

        public int ReadingRoom{ get; set; }

        public int RackNumber { get; set; }
        public int ShelfNumber { get; set; }

        public DateTime ArrivalDate { get; set; }
        public DateTime OffDate { get; set; }
    }
}