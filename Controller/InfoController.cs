using Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LibraryApiDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IOptionsSnapshot<InfoOptions> _options;
    private readonly IWebHostEnvironment _env;

    public InfoController(IOptionsSnapshot<InfoOptions> options, IWebHostEnvironment env)
    {
        _options = options;
        _env = env;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            _options.Value.Name,
            _options.Value.WelcomeMessage,
            Environment = _env.EnvironmentName
        });
    }
}
