using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AIS_Library.Models.Users;
using AIS_Library.DAO.Repositories;

namespace AIS_Library.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Abonement> Abonements { get; set; }
        public DbSet<AbonementLog> AbonementLogs { get; set; }
        public DbSet<BookProperty> BookProperties { get; set; }
        public DbSet<CompositionType> CompositionTypes { get; set; }
        public DbSet<Issuance> Issuances { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryFund> LibraryFunds { get; set; }
        public DbSet<UsingRules> UsingRuless { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Scientist> Scientists { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User>  Userss { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public class StoreDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                

                LibrarianRepository rep = new LibrarianRepository(context);
                Librarian[] libr = new Librarian[]
                {
                    new Librarian { ReadingRoomId = 1 }
                };
            }
        }
    }
}