using System.ComponentModel.DataAnnotations;

namespace GestionMatriculas.Dto
{
    public class CreateCourseDto
    {
        [Required(ErrorMessage = "El título del curso es requerido.")]
        public string Title { get; set; } = string.Empty;
      
    }
}