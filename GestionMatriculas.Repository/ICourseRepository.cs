using GestionMatriculas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}