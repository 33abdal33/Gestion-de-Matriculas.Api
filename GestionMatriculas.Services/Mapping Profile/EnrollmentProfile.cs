using AutoMapper;
using GestionMatriculas.Dto;
using GestionMatriculas.Models;
using GestionMatriculasApi.DTOs;

namespace GestionMatriculas.Services.Mapping_Profile
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
    
            CreateMap<EnrollmentDto, Enrollment>();
            CreateMap<Enrollment, EnrollmentResultDto>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
                .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));

            CreateMap<CreateStudentDto, Student>();
            CreateMap<Student, StudentResultDto>();

 
            CreateMap<CreateCourseDto, Course>();
            CreateMap<Course, CourseResultDto>();
        }
    }
}