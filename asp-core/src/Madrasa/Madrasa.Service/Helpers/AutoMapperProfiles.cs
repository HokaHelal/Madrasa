using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Service.Enum;
using Madrasa.Shared.Extenstions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Madrasa.Service.Helpers;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Madrasa.Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.age, opt => opt
                .MapFrom(src => src.AppUser.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.AppUser.Gender))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.AppUser.Email))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.AppUser.Name))
                .ForMember(dest => dest.photoUrl, opt => opt.MapFrom(src => src.AppUser.PhotoUrl))
                ;

            CreateMap<StudentDto, AppUser>()
                .ForMember(dest => dest.RoleId, opt => opt
                .MapFrom<StudentRoleResolver>());

            CreateMap<NewTopicDto, Topic>();
            CreateMap<NewPostDto, Post>();
            CreateMap<NewTopicDto, Topic>();
            
            CreateMap<TeacherDto, AppUser>()
                .ForMember(dest => dest.RoleId, opt => opt
                .MapFrom<TeacherRoleResolver>());
            CreateMap<AppUser, LoggedUserDto>()
                .ForMember(dest => dest.age, opt => opt
                .MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.roleCode, opt => opt
                .MapFrom<RoleResolver>());
            ;
        }
    }
    public class StudentRoleResolver : IValueResolver<StudentDto, AppUser, int>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public StudentRoleResolver(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        int IValueResolver<StudentDto, AppUser, int>.Resolve(StudentDto source, AppUser AppUser, int destMember, ResolutionContext context)
        {
            var role =  _roleManager.Roles.FirstOrDefault(r => r.RoleCode == (int)RoleCode.Student);

            return role.Id;
        }
    }
    public class TeacherRoleResolver : IValueResolver<TeacherDto, AppUser, int>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public TeacherRoleResolver(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        int IValueResolver<TeacherDto, AppUser, int>.Resolve(TeacherDto source, AppUser AppUser, int destMember, ResolutionContext context)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.RoleCode == (int)RoleCode.Teacher);

            return role.Id;
        }
    }
    public class RoleResolver : IValueResolver<AppUser, LoggedUserDto, string>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleResolver(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        string IValueResolver<AppUser, LoggedUserDto, string>.Resolve(AppUser source, LoggedUserDto AppUser, string destMember, ResolutionContext context)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Id == source.RoleId);

            return role.RoleCode.ToString();
        }
    }


}
