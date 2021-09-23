using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Api.Abstractions
{
    // [Authorize]
    [ApiController]
    [Produces("application/json")]

    //[Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public abstract class BaseController : ControllerBase
    {
    }
}
