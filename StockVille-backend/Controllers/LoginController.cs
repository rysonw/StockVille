using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    public IActionResult GetData()
    {
        var data = "example data";
        return Ok(data);
    }

    [HttpPost]
    public IActionResult PostData([FromBody] object payload)
    {
        // handle the posted data
        return Ok();
    }
}