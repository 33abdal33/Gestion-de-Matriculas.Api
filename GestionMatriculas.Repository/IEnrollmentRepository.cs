using GestionMatriculas.Models;
using GestionMatriculasApi.DTOs;

namespace GestionMatriculas.Repository
{
    public interface IEnrollmentRepository
    {
        Task<bool> CreateEnrollmentStoredProcAsync(Enrollment enrollment);
        Task<IEnumerable<EnrollmentResultDto>> GetFilteredEnrollmentsAsync(int? studentId, int? courseId, string? status);


    }
}
