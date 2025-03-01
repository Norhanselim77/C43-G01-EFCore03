using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.Models
{

    [Table("Student")]
    class Student
    {
        #region By Convention
        //public int ID { get; set; }
        //public string? FName { get; set; }
        //public string? LName { get; set; }
        //public string? Address { get; set; }
        //public int Age { get; set; }
        //public int Dep_Id { get; set; } 
        #endregion

        #region Data Annotations

        [Key]
        public int ID { get; set; }

        [Required]
        [Column(name: "StudentFirstName", TypeName = "varchar")]
        [MaxLength(50, ErrorMessage = "Name Must be Less Than 51 Char")]
        [MinLength(3, ErrorMessage = "Name Must be More Than Two Char")]
        [StringLength(50, ErrorMessage = "Name Must be Less Than 51 Char", MinimumLength = 3)]
        [Length(3, 50)]
        public string? FName { get; set; }

        [Required]
        [Column(name: "StudentLastName", TypeName = "varchar")]
        [MaxLength(50, ErrorMessage = "Name Must be Less Than 51 Char")]
        [MinLength(3, ErrorMessage = "Name Must be More Than Two Char")]
        [StringLength(50, ErrorMessage = "Name Must be Less Than 51 Char", MinimumLength = 3)]
        [Length(3, 50)]
        public string? LName { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [Range(18, 50)]
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int Dep_Id { get; set; }
        public Department Department { get; set; }
        public ICollection<StudCourse> StudentCourses { get; set; }

        #endregion
    }
}