using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentCourseRepository
    {
        private readonly SchoolDbContext _context;

        public StudentCourseRepository()
        {
            _context = new SchoolDbContext();
        }

        public void AddEnrollment(int studentId, int courseId)
        {
            _context.StudentCourses.Add(new StudentCourse
            {
                StudentID = studentId,
                CourseID = courseId
            });
            _context.SaveChanges();
        }

        public List<StudentCourse> GetEnrollmentsByCourse(int courseId)
        {
            return _context.StudentCourses.Where(sc => sc.CourseID == courseId).ToList();
        }

        public List<StudentCourse> GetAllEnrollments()
        {
            return _context.StudentCourses.ToList();
        }

        public void UpdateEnrollment(int studentId, int newCourseId)
        {
            var existing = _context.StudentCourses.FirstOrDefault(sc => sc.StudentID == studentId);
            if (existing != null)
            {
                _context.StudentCourses.Remove(existing);
                _context.StudentCourses.Add(new StudentCourse
                {
                    StudentID = studentId,
                    CourseID = newCourseId
                });
                _context.SaveChanges();
            }
        }

        public void DeleteEnrollment(int studentId)
        {
            var enrollment = _context.StudentCourses.FirstOrDefault(sc => sc.StudentID == studentId);
            if (enrollment != null)
            {
                _context.StudentCourses.Remove(enrollment);
                _context.SaveChanges();
            }
        }
    }
}