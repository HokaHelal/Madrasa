using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsByClassId(int classId, int excludeSudentId = -1)
        {
            var query = _context.Students.Include(u => u.AppUser).AsQueryable();
            
            query = query.Where(u => u.ClassId == classId);

            if (excludeSudentId != -1)
            {
                query = query.Where(u => u.Id != excludeSudentId);
            }

            query = query.OrderByDescending(x => x.AppUser.LastActive);

            return await query.ToListAsync();
        }
    }
}
