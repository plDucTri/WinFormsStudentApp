using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tblStudents")]
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int YearOfEnroll { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }
    }
}