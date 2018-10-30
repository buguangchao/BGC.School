using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("注册时间")]
        public DateTime EnrollDate { get; set; }

        public Office Office { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
