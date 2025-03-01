using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.Models
{
    [Table("Department")]
    class Department
    {
        #region By Convention
        //public int ID { get; set; }
        //public string? Name { get; set; }
        //public int Ins_ID { get; set; }
        //public DateTime HiringDate { get; set; }
        #endregion

        #region Data Annotations

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Ins_ID { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime HiringDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors { get; set; }

        #endregion
    }
}