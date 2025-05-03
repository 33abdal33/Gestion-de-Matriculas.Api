using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Models;
using GestionMatriculas.Repository;
using GestionMatriculas.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionMatriculas.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentResultDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentResultDto>>(students);
        }

        public async Task<StudentResultDto> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return _mapper.Map<StudentResultDto>(student);
        }

        public async Task<StudentResultDto> AddAsync(CreateStudentDto createStudentDto)
        {
            var student = _mapper.Map<Student>(createStudentDto);
            var addedStudent = await _repository.AddAsync(student);
            return _mapper.Map<StudentResultDto>(addedStudent);
        }

        public async Task<bool> UpdateAsync(int id, CreateStudentDto createStudentDto)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return false;
            }
            var student = _mapper.Map<Student>(createStudentDto);
            student.Id = id;
            return await _repository.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}