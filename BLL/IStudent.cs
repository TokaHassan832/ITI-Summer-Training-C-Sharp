using mvc1.Models;

namespace mvc1.BLL
{
    public interface IStudent
    {
        public List<Student> GetAll();

        public Student GetbyId(int id);

        public Student Update(Student std);

        public Student Add(Student std);

        public void Delete(int id);
    }
}

