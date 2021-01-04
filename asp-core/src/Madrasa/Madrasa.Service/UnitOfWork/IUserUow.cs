using Madrasa.Dto;
using Madrasa.Repository;
using Madrasa.Repository.Account;
using Madrasa.Shared.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public interface IUserUow : IGenericUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task<LoggedUserDto> RegisterAsync(StudentDto student);
        Task<LoggedUserDto> RegisterAsync(TeacherDto techerDto);
        Task<LoggedUserDto> LogInAsync(LoginDto loginDto);
        Task<IEnumerable<StudentDto>> GetStudentsByClassId(int classId, int excludeSudentId = -1);
    }
}
