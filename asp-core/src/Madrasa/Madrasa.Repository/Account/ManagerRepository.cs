using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        private readonly DataContext _context;

        public ManagerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
