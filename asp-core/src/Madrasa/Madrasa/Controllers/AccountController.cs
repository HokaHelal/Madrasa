using Madrasa.Dto;
using Madrasa.Service.Interfaces;
using Madrasa.Service.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserUow _unitOfWork;
        private static ILogger<AccountController> _logger;

        public AccountController(IUserUow unitOfWork, ILogger<AccountController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost("new-student")]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            var newUser = await _unitOfWork.RegisterAsync(studentDto);

            return Ok(newUser);
        }
        [HttpPost("new-teacher")]
        public async Task<IActionResult> AddTeacher(TeacherDto teacherDto)
        {
            var newUser = await _unitOfWork.RegisterAsync(teacherDto);

            return Ok(newUser);
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            _logger.LogInformation("Try login...");
            var loggedser = await _unitOfWork.LogInAsync(loginDto);

            return Ok(loggedser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.UserRepository.GetAllAsync();

            return Ok(students);
        }
    }
}
