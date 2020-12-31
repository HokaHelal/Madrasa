using AutoMapper;
using Madrasa.Repository;
using Madrasa.Shared.Generic;

namespace Madrasa.Service.UnitOfWork
{
    public class SemesterUow : GenericUnitOfWork, ISemesterUow
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ISessionRepository SessionRepository => new SessionRepository(_context);

        public ISubjectRepository SubjectRepository => new SubjectRepository(_context);

        public SemesterUow(DataContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
