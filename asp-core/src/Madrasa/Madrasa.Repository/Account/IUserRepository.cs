using Madrasa.Models;
using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Repository.Account
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<IEnumerable<AppUser>> FindByAsync(Expression<Func<AppUser, bool>> predicate);
        Task<AppUser> GetByIdAsync(int Id);
        Task<AppUser> FindFirstAsync(Expression<Func<AppUser, bool>> predicate);
        Task<int> CountAsync();
    }
}
