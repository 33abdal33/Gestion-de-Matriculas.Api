using GestionMatriculas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}