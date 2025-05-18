using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SyllabusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API is working!");
    }
}
