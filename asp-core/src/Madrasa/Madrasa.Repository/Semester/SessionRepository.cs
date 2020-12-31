using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly DataContext _context;

        public SessionRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
