using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Models;
using GestionMatriculas.Persistence;
using GestionMatriculas.Repository;
using GestionMatriculas.Services.Interfaces;
using GestionMatriculasApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionMatriculas.Services.Implementation
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EnrollmentService(
            IEnrollmentRepository repository,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<EnrollmentResultDto> CreateEnrollmentAsync(EnrollmentDto enrollmentDto)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.Id == enrollmentDto.StudentId);
            if (!studentExists)
                throw new InvalidOperationException("El estudiante no existe.");

            var courseExists = await _context.Courses.AnyAsync(c => c.Id == enrollmentDto.CourseId);
            if (!courseExists)
                throw new InvalidOperationException("El curso no existe.");

            var alreadyEnrolled = await _context.Enrollments.AnyAsync(e =>
                e.StudentId == enrollmentDto.StudentId &&
                e.CourseId == enrollmentDto.CourseId);
            if (alreadyEnrolled)
                throw new InvalidOperationException("El estudiante ya está matriculado en este curso.");

            if (enrollmentDto.EnrollmentDate > DateTime.Now.Date)
                throw new InvalidOperationException("La fecha de matrícula no puede ser futura.");

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            var success = await _repository.CreateEnrollmentStoredProcAsync(enrollment);
            if (!success)
                return null; // O lanza una excepción específica

            // Después de crear con SP, podrías necesitar obtener el resultado para el DTO
            var createdEnrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId && e.EnrollmentDate == enrollment.EnrollmentDate);

            return _mapper.Map<EnrollmentResultDto>(createdEnrollment);
        }

        public async Task<bool> UpdateEnrollmentStatusAsync(int enrollmentId, string newStatus)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
                throw new InvalidOperationException("La matrícula no existe.");

            if (enrollment.Status == "Finalizada" && newStatus == "Cancelada")
                throw new InvalidOperationException("No se puede cancelar una matrícula finalizada.");

            enrollment.Status = newStatus;
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
                throw new InvalidOperationException("La matrícula no existe.");

            if (enrollment.Status != "Cancelada")
                throw new InvalidOperationException("Solo se pueden eliminar matrículas en estado 'Cancelada'.");

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EnrollmentResultDto>> GetFilteredEnrollmentsAsync(int? id, int? studentId, int? courseId, string? status)
        {
            // Por ahora, el repositorio ya maneja el filtrado con SP
            return await _repository.GetFilteredEnrollmentsAsync(studentId, courseId, status);
        }

        public async Task<EnrollmentResultDto> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Id == id)
                .Select(e => _mapper.Map<EnrollmentResultDto>(e))
                .FirstOrDefaultAsync();

            return enrollment;
        }
    }
}