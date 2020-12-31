using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Repository.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> FindByAsync(Expression<Func<AppUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindFirstAsync(Expression<Func<AppUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
