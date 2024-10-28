using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    //[Keyless]
    public class Enrollment
    {
        
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public int StudItemId { get; set; }
        [ForeignKey("StudItemId")]
        public StudItem? StudItem { get; set; }

    }
}
