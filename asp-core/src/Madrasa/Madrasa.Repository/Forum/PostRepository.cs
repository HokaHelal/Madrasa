using Madrasa.Models;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
