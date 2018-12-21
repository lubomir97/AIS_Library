using AIS_Library.Models;
using AIS_Library.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.BL.Interfaces
{
    public interface IManageUsers
    {
        IEnumerable<User> GetUser(int id);
        IEnumerable<User> GetBookUsers(string book);
        IEnumerable<User> GetTimeUser(DateTime start, DateTime end, string name);
        IEnumerable<User> FindUserForLibrarian(DateTime start, DateTime end, string librarian);
        IEnumerable<User> Overdue();
        IEnumerable<User> NotVisit(DateTime start, DateTime end);

    }
}
