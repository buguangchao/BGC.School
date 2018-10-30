using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class Course
    {
        public int Id { get; set; }

        [DisplayName("课程名称")]
        [StringLength(30, ErrorMessage = "不能超过30个字符")]
        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
