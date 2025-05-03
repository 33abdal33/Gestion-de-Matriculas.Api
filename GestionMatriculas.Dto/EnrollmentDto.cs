using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMatriculas.Dto
{
    public class EnrollmentDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
    }
}
