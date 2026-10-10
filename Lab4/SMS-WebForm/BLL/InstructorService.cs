using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorService()
        {
            _instructorRepository = new InstructorRepository();
        }

        public void AddInstructor(Instructor instructor) => _instructorRepository.AddInstructor(instructor);
        public Instructor GetInstructor(int id) => _instructorRepository.GetInstructorById(id);
        public List<Instructor> GetAllInstructors() => _instructorRepository.GetAllInstructors();
        public void UpdateInstructor(Instructor instructor) => _instructorRepository.UpdateInstructor(instructor);
        public void DeleteInstructor(int id) => _instructorRepository.DeleteInstructor(id);
    }
}