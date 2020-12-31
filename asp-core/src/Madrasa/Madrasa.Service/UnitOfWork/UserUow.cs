using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Repository;
using Madrasa.Repository.Account;
using Madrasa.Shared.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public class UserUow : GenericUnitOfWork, IUserUow
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public IUserRepository UserRepository => new UserRepository(_context);

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserUow(DataContext context, IMapper mapper,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<NewStudentDto> RegisterAsync(StudentDto studentDto)
        {

            var user = _mapper.Map<AppUser>(studentDto);

            var result = await _userManager.CreateAsync(user, studentDto.password);
            var role = await _userManager.AddToRoleAsync(user, "Student");

            if (result.Succeeded && role.Succeeded)
            {
                var retStudent = _mapper.Map<NewStudentDto>(user);

                return retStudent;
            }

            return null;
        }
    }
}
