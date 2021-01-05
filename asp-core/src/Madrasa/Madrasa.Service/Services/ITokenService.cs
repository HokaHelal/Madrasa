using Madrasa.Models;
using System.Threading.Tasks;

namespace Madrasa.Service.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser appUser);
    }
}
