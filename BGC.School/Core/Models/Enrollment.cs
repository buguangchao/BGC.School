using BGC.School.Application.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public CourseGrade? Grade { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
