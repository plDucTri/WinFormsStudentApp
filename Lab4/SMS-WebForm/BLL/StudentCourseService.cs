using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StudentCourseService
    {
        private readonly StudentCourseRepository _studentCourseRepository;

        public StudentCourseService()
        {
            _studentCourseRepository = new StudentCourseRepository();
        }

        public void AddEnrollment(int studentId, int courseId) => _studentCourseRepository.AddEnrollment(studentId, courseId);
        public List<StudentCourse> GetEnrollmentsByCourse(int courseId) => _studentCourseRepository.GetEnrollmentsByCourse(courseId);
        public List<StudentCourse> GetAllEnrollments() => _studentCourseRepository.GetAllEnrollments();
        public void UpdateEnrollment(int studentId, int newCourseId) => _studentCourseRepository.UpdateEnrollment(studentId, newCourseId);
        public void DeleteEnrollment(int studentId) => _studentCourseRepository.DeleteEnrollment(studentId);
    }
}