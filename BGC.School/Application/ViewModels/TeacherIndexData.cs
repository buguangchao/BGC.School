using BGC.School.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Application.ViewModels
{
    public class TeacherIndexData
    {
        public List<Teacher> TeachersList { get; set; }
        public List<Course> CourseList { get; set; }
        public List<Enrollment> EnrollmentList { get; set; }
    }
}
