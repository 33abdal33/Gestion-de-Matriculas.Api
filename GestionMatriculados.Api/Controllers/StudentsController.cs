using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResultDto>>> GetAll()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResultDto>> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResultDto>> Create(CreateStudentDto createStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = await _service.AddAsync(createStudentDto);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateStudentDto createStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _service.UpdateAsync(id, createStudentDto))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}