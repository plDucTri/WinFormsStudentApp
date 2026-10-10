using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public void AddDepartment(Department department) => _departmentRepository.AddDepartment(department);
        public Department GetDepartment(int id) => _departmentRepository.GetDepartmentById(id);
        public List<Department> GetAllDepartments() => _departmentRepository.GetAllDepartments();
        public void UpdateDepartment(Department department) => _departmentRepository.UpdateDepartment(department);
        public void DeleteDepartment(int id) => _departmentRepository.DeleteDepartment(id);
    }
}