using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tblDepartments")]
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}