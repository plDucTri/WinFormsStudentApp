using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InstructorRepository
    {
        private readonly SchoolDbContext _context;

        public InstructorRepository()
        {
            _context = new SchoolDbContext();
        }

        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(i => i.InstructorID == id);
        }

        public List<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            var existing = _context.Instructors.FirstOrDefault(i => i.InstructorID == instructor.InstructorID);
            if (existing != null)
            {
                existing.InstructorName = instructor.InstructorName;
                existing.DepartmentID = instructor.DepartmentID;
                _context.SaveChanges();
            }
        }

        public void DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}