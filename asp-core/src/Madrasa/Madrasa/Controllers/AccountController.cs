using Madrasa.Dto;
using Madrasa.Service.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserUow _unitOfWork;

        public AccountController(IUserUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentDto studentDto)
        {
            var newStudent = await _unitOfWork.RegisterAsync(studentDto);

            return Ok(newStudent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.UserRepository.GetAllAsync();

            return Ok(students);
        }
    }
}
