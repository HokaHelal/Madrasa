using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Service.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, NewStudentDto>()
                .ForMember(dest => dest.age, opt => opt
                .MapFrom(src => src.DateOfBirth.CalculateAge()));
        }
    }
}
