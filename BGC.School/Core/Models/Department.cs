using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "不能超过30个字符")]
        public string Name { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
