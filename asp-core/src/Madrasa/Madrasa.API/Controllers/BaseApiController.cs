using Madrasa.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Madrasa.API.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
      
    }
}
