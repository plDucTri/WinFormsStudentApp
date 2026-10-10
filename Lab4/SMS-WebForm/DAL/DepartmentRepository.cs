using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentRepository
    {
        private readonly SchoolDbContext _context;

        public DepartmentRepository()
        {
            _context = new SchoolDbContext();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void UpdateDepartment(Department department)
        {
            var existing = _context.Departments.FirstOrDefault(d => d.DepartmentID == department.DepartmentID);
            if (existing != null)
            {
                existing.DepartmentName = department.DepartmentName;
                _context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}