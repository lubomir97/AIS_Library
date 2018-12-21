using AIS_Library.Models;
using AIS_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.BL.Interfaces
{
    public interface IManageBooks
    {
        IEnumerable<BookProperty> GetBooks(DateTime start, DateTime end, string user);
        IEnumerable<BookProperty> GetBooksAnotherLibrary(DateTime start, DateTime end, int user);
        IEnumerable<BookProperty> ArrivedBooks(DateTime start, DateTime end);
        IEnumerable<BookProperty> WrittenOffBooks(DateTime start, DateTime end);

        IEnumerable<PopularViewModel> GetPopularBooks();

        IEnumerable<LibraryFund> GetPosition(string book_name);
        IEnumerable<LibraryFund> GetPositionForAutor(string autor);

    }
}
