using Madrasa.Repository.Account;
using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Repository.UnitOfWork
{
    public interface IUserUow : IGenericUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
