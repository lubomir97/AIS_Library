using AIS_Library.Models.Users;
using AIS_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.BL.Interfaces
{
    interface IManageLibrarian
    {
        IEnumerable<LibrarianProductivityViewModel> GetProductivity( DateTime start, DateTime end);
        IEnumerable<Librarian> FindRoom(int room);
    }
}
