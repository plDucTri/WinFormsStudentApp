using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tblStudentCourses")]
    public class StudentCourse
    {
        [Key]
        [Column(Order = 0)]
        public int StudentID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CourseID { get; set; }
    }
}