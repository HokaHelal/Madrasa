using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> CountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<IEnumerable<AppUser>> FindByAsync(Expression<Func<AppUser, bool>> predicate)
        {
            var query = _context.Users.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<AppUser> FindFirstAsync(Expression<Func<AppUser, bool>> predicate)
        {
            var query = await _context.Users.AsNoTracking().FirstOrDefaultAsync(predicate);

            return query;
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync<AppUser>();
        }

        public async Task<AppUser> GetByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}
