using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BGC.School.Core.Models
{
    public class Student
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [DisplayName("姓名")]
        [StringLength(30,ErrorMessage ="不能超过30个字符")]
        public string Name { get; set; }

        [DisplayName("注册时间")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime EnrollDate { get; set; }

        [DisplayName("登记信息")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
