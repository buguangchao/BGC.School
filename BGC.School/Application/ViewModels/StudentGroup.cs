using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Application.ViewModels
{
    public class StudentGroup
    {
        public int Count { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
    }
}
