using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMatriculas.Dto
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "El nombre del estudiante es requerido.")]
        public string Name { get; set; } = string.Empty;
    }
}
