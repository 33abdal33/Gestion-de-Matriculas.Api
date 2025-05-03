using GestionMatriculas.Dto;
using GestionMatriculasApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentResultDto> CreateEnrollmentAsync(EnrollmentDto enrollmentDto);
        Task<bool> UpdateEnrollmentStatusAsync(int enrollmentId, string newStatus);
        Task<bool> DeleteEnrollmentAsync(int enrollmentId);
        Task<IEnumerable<EnrollmentResultDto>> GetFilteredEnrollmentsAsync(int? id, int? studentId, int? courseId, string? status);
        Task<EnrollmentResultDto> GetEnrollmentByIdAsync(int id);
    }
}