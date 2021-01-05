using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
