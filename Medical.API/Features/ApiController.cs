using Microsoft.AspNetCore.Mvc;

namespace Medical.API.Features
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
    }
}
