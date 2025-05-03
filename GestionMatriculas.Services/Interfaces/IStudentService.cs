using GestionMatriculas.Dto;

namespace GestionMatriculas.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResultDto>> GetAllAsync();
        Task<StudentResultDto> GetByIdAsync(int id);
        Task<StudentResultDto> AddAsync(CreateStudentDto createStudentDto);
        Task<bool> UpdateAsync(int id, CreateStudentDto createStudentDto);
        Task<bool> DeleteAsync(int id);
    }
}