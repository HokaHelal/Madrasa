using Madrasa.Models;
using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByClassId(int classId, int excludeSudentId = -1);
    }
}
