using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Application.Dto
{
    public class StudentDto
    {
        [Required]
        [DisplayName("姓名")]
        [StringLength(30, ErrorMessage = "不能超过30个字符")]
        public string Name { get; set; }

        [DisplayName("注册时间")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }
    }
}
