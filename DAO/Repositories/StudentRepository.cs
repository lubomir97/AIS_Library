using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Student item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Students.Find(id);
            if (value != null)
            {
                db.Students.Remove(value);
            }
        }

        public Student Get(int id)
        {
            Student stud = db.Students.Find(id);
            stud.User = db.Userss.Find(stud.UserId);
            stud.Faculty = db.Faculties.Find(stud.FacultyId);
            return stud;
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}