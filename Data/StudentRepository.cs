using System.Linq.Expressions;
using TP4.Models;

namespace TP4.Data
{
    public class StudentRepository
    {
        private UniversityContext universityContext;
        public StudentRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        public bool Add(Student s)
        {
            universityContext.student.Add(s);
            universityContext.SaveChanges();
            return true;
        }
        public bool Remove(Student s)
        {
            universityContext.student.Remove(s);
            universityContext.SaveChanges();
            return true;
        }
        public IEnumerable<Student> GetAll()
        {
            return universityContext.student.ToList();
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return universityContext.student.Where(predicate);
        }
        public Student Get(int id)
        {
            return universityContext.student.Find(id);
        }
        public IEnumerable<string> GetCourses()
        {
            return universityContext.student.Select(s => s.course).Distinct().ToList();
        }
    }
}
