using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public void AddCourse(Course course) => _courseRepository.AddCourse(course);
        public Course GetCourse(int id) => _courseRepository.GetCourseById(id);
        public List<Course> GetAllCourses() => _courseRepository.GetAllCourses();
        public void UpdateCourse(Course course) => _courseRepository.UpdateCourse(course);
        public void DeleteCourse(int id) => _courseRepository.DeleteCourse(id);
    }
}