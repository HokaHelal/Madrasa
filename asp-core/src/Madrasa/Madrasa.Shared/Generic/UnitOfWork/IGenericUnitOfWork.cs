
using System;
using System.Threading.Tasks;

namespace Madrasa.Shared.Generic
{
   public interface IGenericUnitOfWork : IDisposable
   {
 
       /// <summary>
       /// Saves all pending changes
       /// </summary>
       /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
       Task<int> CommitAsync();
       bool HasChanges();

    }
}