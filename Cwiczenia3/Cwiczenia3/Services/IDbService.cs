using Cwiczenia3.Models;
using System.Collections.Generic;

namespace Cwiczenia3.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(string id);
        public bool AddStudent(Student student);
        public bool UpdateStudent(Student student);
        public bool DeleteStudent(string id);
    }
}
