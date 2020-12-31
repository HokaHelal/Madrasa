using Madrasa.Models;
using Madrasa.Repository.UnitOfWork;
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
        public async Task<IActionResult> Add(Student student)
        {
            bool isCreated = await _unitOfWork.UserRepository.AddAsync(student);
            int isSuccessed = await _unitOfWork.CommitAsync();

            return Ok("User Created Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.UserRepository.GetAllAsync();

            return Ok(students);
        }
    }
}
