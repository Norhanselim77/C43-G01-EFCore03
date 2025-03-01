using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.Models
{
    [Table("Instructor")]
    class Instructor
    {
        #region By Convention
        //public int ID { get; set; }
        //public string? Name { get; set; }
        //public decimal Salary { get; set; }
        //public string? Address { get; set; }
        //public decimal HourRateBonus { get; set; }
        //public int Dept_ID { get; set; }
        #endregion

        #region Data Annotations

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRate { get; set; }
        public int Dept_ID { get; set; }
        public Department Departments { get; set; }
        public ICollection<CourseInst> InstructorCourses { get; set; }

        #endregion
    }
}