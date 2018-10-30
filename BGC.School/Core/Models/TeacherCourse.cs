using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class TeacherCourse
    {
        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
