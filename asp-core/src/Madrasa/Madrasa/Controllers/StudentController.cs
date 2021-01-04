using Madrasa.Service.UnitOfWork;
using Madrasa.Shared.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IUserUow _userUow;

        public StudentController(IUserUow userUow)
        {
            _userUow = userUow;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetClassmates(int studentId)
        {
            var student = await _userUow.StudentRepository.GetByIdAsync(studentId);

            if (student == null)
            {
                throw new NotFoundException("Logged user is not student.");
            }

            var users = await _userUow.GetStudentsByClassId(student.ClassId, student.Id);

            return Ok(users);
        }
    }
}
