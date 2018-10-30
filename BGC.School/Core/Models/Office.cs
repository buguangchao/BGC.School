using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.Core.Models
{
    public class Office
    {
        [Key]
        public int TeacherId { get; set; }

        [DisplayName("办公室位置")]
        public string Location { get; set; }

        public Teacher Teacher { get; set; }

    }
}
