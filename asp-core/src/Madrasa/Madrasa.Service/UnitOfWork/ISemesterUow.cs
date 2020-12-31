using Madrasa.Repository;
using Madrasa.Shared.Generic;

namespace Madrasa.Service.UnitOfWork
{
    public interface ISemesterUow : IGenericUnitOfWork
    {
        ISessionRepository SessionRepository { get; }
        ISubjectRepository SubjectRepository { get; }
    }
}
