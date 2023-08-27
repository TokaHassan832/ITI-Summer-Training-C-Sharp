using Microsoft.EntityFrameworkCore;
using mvc1.Models;

namespace mvc1.BLL
{
    public class StudentBLL : IStudent
    {
        ITIContext db = new ITIContext();
        public List<Student> GetAll()
        {
            return db.Students.Include(x=>x.Department).ToList();
        }

        public Student GetbyId(int id) 
        { 
            return db.Students.Include(x => x.Department).FirstOrDefault(a => a.Id == id);
        }

        public Student Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
            return student;
        }

        public void Delete(int id)
        {
            Student student = db.Students.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public Student Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
