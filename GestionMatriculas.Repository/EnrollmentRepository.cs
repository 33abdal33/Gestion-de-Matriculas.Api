using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using GestionMatriculas.Models;
using GestionMatriculas.Persistence;
using GestionMatriculasApi.DTOs;

namespace GestionMatriculas.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEnrollmentStoredProcAsync(Enrollment enrollment)
        {
            var connection = _context.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "sp_CreateEnrollment";
                command.CommandType = CommandType.StoredProcedure;

                var studentIdParam = new SqlParameter("@StudentId", enrollment.StudentId);
                var courseIdParam = new SqlParameter("@CourseId", enrollment.CourseId);
                var dateParam = new SqlParameter("@EnrollmentDate", enrollment.EnrollmentDate);
                var statusParam = new SqlParameter("@Status", enrollment.Status);

                command.Parameters.Add(studentIdParam);
                command.Parameters.Add(courseIdParam);
                command.Parameters.Add(dateParam);
                command.Parameters.Add(statusParam);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
            catch(Exception ex)
            {

                throw new Exception("Error al crear la matrícula", ex);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<EnrollmentResultDto>> GetFilteredEnrollmentsAsync(int? studentId, int? courseId, string? status)
        {
            var connection = _context.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = "sp_GetFilteredEnrollments";
                command.CommandType = CommandType.StoredProcedure;

                if (studentId.HasValue)
                    command.Parameters.Add(new SqlParameter("@StudentId", studentId.Value));
                else
                    command.Parameters.Add(new SqlParameter("@StudentId", DBNull.Value));

                if (courseId.HasValue)
                    command.Parameters.Add(new SqlParameter("@CourseId", courseId.Value));
                else
                    command.Parameters.Add(new SqlParameter("@CourseId", DBNull.Value));

                if (!string.IsNullOrWhiteSpace(status))
                    command.Parameters.Add(new SqlParameter("@Status", status));
                else
                    command.Parameters.Add(new SqlParameter("@Status", DBNull.Value));

                using var reader = await command.ExecuteReaderAsync();
                var enrollments = new List<EnrollmentResultDto>();

                while (await reader.ReadAsync())
                {
                    enrollments.Add(new EnrollmentResultDto
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")), 
                        StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                        CourseId = reader.GetInt32(reader.GetOrdinal("CourseId")),
                        CourseTitle = reader.GetString(reader.GetOrdinal("CourseTitle")),
                        EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                        Status = reader.GetString(reader.GetOrdinal("Status"))
                    });
                }

                return enrollments;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las matrículas filtradas", ex);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

    }
}
