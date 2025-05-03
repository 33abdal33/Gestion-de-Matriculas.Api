using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Models;
using GestionMatriculas.Repository;
using GestionMatriculas.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseResultDto>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseResultDto>>(courses);
        }

        public async Task<CourseResultDto> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return _mapper.Map<CourseResultDto>(course);
        }

        public async Task<CourseResultDto> AddAsync(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);
            var addedCourse = await _repository.AddAsync(course);
            return _mapper.Map<CourseResultDto>(addedCourse);
        }

        public async Task<bool> UpdateAsync(int id, CreateCourseDto createCourseDto)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return false;
            }
            var course = _mapper.Map<Course>(createCourseDto);
            course.Id = id;
            return await _repository.UpdateAsync(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}