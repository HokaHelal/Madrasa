using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        private readonly DataContext _context;

        public SectionRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
