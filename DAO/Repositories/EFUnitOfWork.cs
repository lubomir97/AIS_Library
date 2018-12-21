using AIS_Library.Models.Users;
using AIS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.DAO.Interfaces;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class EFUnitOfWork :IUnitofWork
    {

        private ApplicationDbContext db;

        private AbonementRepository abonementRepository { get; set; }
        private AbonementLogRepository abonementLogRepository { get; set; }
        private BookPropertyRepository bookPropertyRepository { get; set; }
        private CompositionTypeRepository compositionTypeRepository { get; set; }
        private IssuanceRepository issuanceRepository { get; set; }
        private LibrarianRepository librarianRepository { get; set; }
        private LibraryRepository libraryRepository { get; set; }
        private LibraryFundRepository libraryFundRepository { get; set; }
        private UsingRulesRepository usingRulesRepository { get; set; }
        private VisitLogRepository visitLogRepository { get; set; }
        private FacultyRepository facultyRepository { get; set; }
        private OrganizationRepository organizationRepository { get; set; }
        private ScientistRepository scientistRepository { get; set; }
        private StudentRepository studentRepository { get; set; }
        private UniversityRepository universityRepository { get; set; }
        private UserRepository userRepository { get; set; }
        private WorkerRepository workerRepository { get; set; }

        public EFUnitOfWork()
        {
            db = new ApplicationDbContext();
        }   

        public IRepository<Abonement> Abonements
        {
            get
            {
                if(abonementRepository == null)
                    abonementRepository = new AbonementRepository(db);

                return abonementRepository;
            }
        }

        public IRepository<AbonementLog> AbonementLogs
        {
            get
            {
                if(abonementLogRepository == null)
                    abonementLogRepository = new AbonementLogRepository(db);

                return abonementLogRepository;
            }      
        }

        public IRepository<BookProperty> BookProperties
        {
            get
            {
                if (bookPropertyRepository == null)
                    bookPropertyRepository = new BookPropertyRepository(db);

                return bookPropertyRepository;
            }
        }

        public IRepository<CompositionType> CompositionTypes
        {
            get
            {
                if (compositionTypeRepository == null)
                    compositionTypeRepository = new CompositionTypeRepository(db);

                return compositionTypeRepository;
            }
        }

        public IRepository<Issuance> Issuances
        {
            get
            {
                if (issuanceRepository == null)
                    issuanceRepository = new IssuanceRepository(db);

                return issuanceRepository;
            }
        }

        public IRepository<Librarian> Librarians
        {
            get
            {
                if (librarianRepository == null)
                    librarianRepository = new LibrarianRepository(db);

                return librarianRepository;
            }
        }

        public IRepository<Library> Libraries
        {
            get
            {
                if (libraryRepository == null)
                    libraryRepository = new LibraryRepository(db);

                return libraryRepository;
            }
        }

        public IRepository<LibraryFund> LibraryFunds
        {
            get
            {
                if (libraryFundRepository == null)
                    libraryFundRepository = new LibraryFundRepository(db);

                return libraryFundRepository;
            }

        }

  

        public IRepository<UsingRules> UsingRuless
        {
            get
            {
                if (usingRulesRepository == null)
                    usingRulesRepository = new UsingRulesRepository(db);

                return usingRulesRepository;
            }

        
        }

        public IRepository<VisitLog> VisitLogs
        {
            get
            {
                if (visitLogRepository == null)
                    visitLogRepository = new VisitLogRepository(db);

                return visitLogRepository;
            }

        }

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultyRepository(db);

                return facultyRepository;
            }
        }

        public IRepository<Organization> Organizations
        {
            get
            {
                if (organizationRepository == null)
                    organizationRepository = new OrganizationRepository(db);

                return organizationRepository;
            }
        }

        public IRepository<Scientist> Scientists
        {
            get
            {
                if (scientistRepository == null)
                    scientistRepository = new ScientistRepository(db);

                return scientistRepository;
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);

                return studentRepository;
            }
        }

        public IRepository<University> Universities
        {
            get
            {
                if (universityRepository == null)
                    universityRepository = new UniversityRepository(db);

                return universityRepository;
            }
        }

        public IRepository<User> Userss
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);

                return userRepository;
            }
        }

        public IRepository<Worker> Workers
        {
            get
            {
                if (workerRepository == null)
                    workerRepository = new WorkerRepository(db);

                return workerRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
    }
}
