using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS_Library.Models;
using AIS_Library.Models.Users;

namespace AIS_Library.DAO.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<Abonement> Abonements { get; }
        IRepository<AbonementLog> AbonementLogs { get; }
        IRepository<BookProperty> BookProperties { get;}
        IRepository<CompositionType> CompositionTypes { get; }
        IRepository<Issuance> Issuances { get; }
        IRepository<Librarian> Librarians { get; }
        IRepository<Library> Libraries { get; }
        IRepository<LibraryFund> LibraryFunds { get; }
        IRepository<UsingRules> UsingRuless { get; }
        IRepository<VisitLog> VisitLogs { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Scientist> Scientists { get; }
        IRepository<Student> Students { get; }
        IRepository<University> Universities { get; }
        IRepository<User> Userss { get;}
        IRepository<Worker> Workers { get; }

        void Save();
    }
}
