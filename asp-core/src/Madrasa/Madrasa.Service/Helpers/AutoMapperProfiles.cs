using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
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
            CreateMap<Student, NewStudentDto>();
        }
    }
}
