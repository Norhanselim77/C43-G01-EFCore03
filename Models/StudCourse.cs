using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.Models
{
    class StudCourse
    {
        public int Stud_ID { get; set; }
        public int Course_ID { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}