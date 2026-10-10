using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository()
        {
            _context = new SchoolDbContext();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseID == id);
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public void UpdateCourse(Course course)
        {
            var existing = _context.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);
            if (existing != null)
            {
                existing.CourseName = course.CourseName;
                existing.Credits = course.Credits;
                existing.DepartmentID = course.DepartmentID;
                existing.InstructorID = course.InstructorID;
                _context.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}