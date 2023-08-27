using Microsoft.EntityFrameworkCore;
using mvc1.Models;

namespace mvc1.BLL
{
    public class DepartmentBLL
    {
        ITIContext db = new ITIContext();

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetbyId(int id)
        {
            return db.Departments.FirstOrDefault(a => a.Id == id);
        }

        public Department Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return department;
        }

        public void Delete(int id)
        {
            Department department = db.Departments.FirstOrDefault(x => x.Id == id);
            db.Departments.Remove(department);
            db.SaveChanges();
        }

        public Department Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return department;
        }
    }
}
