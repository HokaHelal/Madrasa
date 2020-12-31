using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Repository;
using Madrasa.Repository.Account;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public class UserUow : GenericUnitOfWork, IUserUow
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public IUserRepository UserRepository => new UserRepository(_context);

        public UserUow(DataContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NewStudentDto> RegisterAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            if( await UserRepository.AddAsync(student) && await CommitAsync())
            {
                var retStudent = _mapper.Map<NewStudentDto>(student);

                return retStudent;
            }

            return null;
        }
    }
}
