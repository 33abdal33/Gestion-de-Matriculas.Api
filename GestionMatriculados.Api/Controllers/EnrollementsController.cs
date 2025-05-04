using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Services.Interfaces;
using GestionMatriculasApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionMatriculas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _service;
        private readonly IMapper _mapper;

        public EnrollmentsController(IEnrollmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {
            try
            {
                var createdEnrollment = await _service.CreateEnrollmentAsync(enrollmentDto);
                if (createdEnrollment == null)
                    return StatusCode(200, "Creacion exitosa.");

                return CreatedAtAction(nameof(GetEnrollmentById), new { id = createdEnrollment.Id }, createdEnrollment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, $"Error inesperado al crear la matrícula: {ex.Message}");
            }
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentResultDto>>> GetEnrollments(
            [FromQuery] int? id,
            [FromQuery] int? studentId,
            [FromQuery] int? courseId,
            [FromQuery] string? status)
        {
            try
            {
                var enrollments = await _service.GetFilteredEnrollmentsAsync(id, studentId, courseId, status);
                if (enrollments == null || !enrollments.Any())
                {
                    return NotFound("No se encontraron matrículas con los criterios especificados.");
                }
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Error al obtener las matrículas.");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentResultDto>> GetEnrollmentById(int id)
        {
            try
            {
                var enrollment = await _service.GetEnrollmentByIdAsync(id);
                if (enrollment == null)
                {
                    return NotFound($"No se encontró la matrícula con ID {id}.");
                }
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                // Loguear el error aquí
                return StatusCode(500, "Error al obtener la matrícula.");
            }
        }

        // PUT: api/Enrollments/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] EnrollmentStatusUpdateDto updateDto)
        {
            try
            {
                var success = await _service.UpdateEnrollmentStatusAsync(id, updateDto.Status);
                if (!success)
                    return NotFound("Matrícula no encontrada.");

                return NoContent(); 
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Enrollments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            try
            {
                var success = await _service.DeleteEnrollmentAsync(id);
                if (!success)
                    return NotFound("Matrícula no encontrada.");

                return NoContent(); 
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}