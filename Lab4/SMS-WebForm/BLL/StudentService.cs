using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void AddStudent(Student student) => _studentRepository.AddStudent(student);
        public Student GetStudent(int id) => _studentRepository.GetStudentById(id);
        public List<Student> GetAllStudents() => _studentRepository.GetAllStudents();
        public void UpdateStudent(Student student) => _studentRepository.UpdateStudent(student);
        public void DeleteStudent(int id) => _studentRepository.DeleteStudent(id);
    }
}