using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Repository;
using Madrasa.Repository.Account;
using Madrasa.Service.Interfaces;
using Madrasa.Shared.Errors;
using Madrasa.Shared.Extenstions;
using Madrasa.Shared.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public class UserUow : GenericUnitOfWork, IUserUow
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public IUserRepository UserRepository => new UserRepository(_context);
        public ITeacherRepository TeacherRepository => new TeacherRepository(_context);
        public IStudentRepository StudentRepository => new StudentRepository(_context);

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserUow(DataContext context,
            ITokenService tokenService,
            IMapper mapper,
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager) : base(context)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<LoggedUserDto> RegisterAsync(StudentDto studentDto)
        {

            var user = _mapper.Map<AppUser>(studentDto);
            var result = await _userManager.CreateAsync(user, studentDto.password);
            var role = await _userManager.AddToRoleAsync(user, "Student");
            
            if (result.Succeeded && role.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var newStudent = new Student(userId.ToInt(), studentDto.classId);
                bool isAdded = await StudentRepository.AddAsync(newStudent);
                bool isCreated = await CommitAsync();

                if (isAdded && isCreated)
                {
                    var retStudent = _mapper.Map<LoggedUserDto>(user);

                    return retStudent; 
                }
                else if (!isAdded) throw new BadRequestException("unable to add new user");
                else if (!isCreated) throw new BadRequestException("unable to add new teacher");
                else throw new BadRequestException("unable to add new user and teacher");
            }

            throw new BadRequestException("error while regiter");
        }

        public async Task<LoggedUserDto> RegisterAsync(TeacherDto techerDto)
        {

            var user = _mapper.Map<AppUser>(techerDto);
            var result = await _userManager.CreateAsync(user, techerDto.password);
            var role = await _userManager.AddToRoleAsync(user, "Teacher");

            if (result.Succeeded && role.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var newTecher = new Teacher(userId.ToInt(), techerDto.subjectId);
                bool isAdded = await TeacherRepository.AddAsync(newTecher);
                bool isCreated = await CommitAsync();

                if (isAdded && isCreated)
                {
                    var retStudent = _mapper.Map<LoggedUserDto>(user);

                    return retStudent;
                }
                else if (!isAdded) throw new BadRequestException("unable to add new user");
                else if (!isCreated) throw new BadRequestException("unable to add new teacher");
                else throw new BadRequestException("unable to add new user and teacher");
                
                throw new BadRequestException("error while regiter");               
            }

            throw new Exception("Unable to register new teacher");
        }

        public async Task<LoggedUserDto> LogInAsync(LoginDto loginDto)
        {
            var usr = await _userManager.Users
                            .SingleOrDefaultAsync(x => x.UserName == loginDto.username || x.Email == loginDto.username);

            if (usr == null) throw new BadRequestException("Invalid Username or password");

            var result = await _signInManager.CheckPasswordSignInAsync(usr, loginDto.password, false);

            if (!result.Succeeded) throw new BadRequestException("Invalid Username or password");

            var retUser = _mapper.Map<LoggedUserDto>(usr);
            retUser.token = await _tokenService.CreateTokenAsync(usr);

            return retUser;

        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByClassId(int classId, int excludeSudentId = -1)
        {
            var users = await StudentRepository.GetStudentsByClassId(classId, excludeSudentId);

            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(users);
            
           return studentsDto;
        }

    }
}
