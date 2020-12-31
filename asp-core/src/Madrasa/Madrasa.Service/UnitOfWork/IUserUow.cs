using Madrasa.Dto;
using Madrasa.Repository.Account;
using Madrasa.Shared.Generic;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public interface IUserUow : IGenericUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<NewStudentDto> RegisterAsync(StudentDto student);
    }
}
