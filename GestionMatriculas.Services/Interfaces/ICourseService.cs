using GestionMatriculas.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResultDto>> GetAllAsync();
        Task<CourseResultDto> GetByIdAsync(int id);
        Task<CourseResultDto> AddAsync(CreateCourseDto createCourseDto);
        Task<bool> UpdateAsync(int id, CreateCourseDto createCourseDto);
        Task<bool> DeleteAsync(int id);
    }
}