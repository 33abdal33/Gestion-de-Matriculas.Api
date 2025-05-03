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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResultDto>>> GetAll()
        {
            var courses = await _service.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResultDto>> GetById(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseResultDto>> Create(CreateCourseDto createCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = await _service.AddAsync(createCourseDto);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateCourseDto createCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _service.UpdateAsync(id, createCourseDto))
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