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
        public IUserRepository UserRepository => new UserRepository(_context);

        public UserUow(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
