using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.Models
{
    [Table("Course")]
    class Course
    {
        #region By Convention 

        //public int ID { get; set; }
        //public int Duration { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public int Top_ID { get; set; }

        #endregion

        #region Data Annotations

        [Key]
        public int Id { get; set; }
        public int Duration { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Topic")]
        public int Top_ID { get; set; }
        public Topic Topics { get; set; }
        public ICollection<CourseInst> InstructorCourses { get; set; }
        public ICollection<StudCourse> StudentCourses { get; set; }

        #endregion
    }
}