using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly DataContext _context;

        public SubjectRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
