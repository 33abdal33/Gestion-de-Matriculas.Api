using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMatriculasApi.DTOs
{
    public class EnrollmentResultDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

