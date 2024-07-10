using Microsoft.AspNetCore.Mvc;

namespace PocApi;

[ApiController]
[Route("api/[controller]")]
public class MyController:ControllerBase
{
    // [HttpPost("PostAsForm")]
    // [Consumes("multipart/form-data")]
    // public async Task<IActionResult> PostAsForm([FromForm] MyRequest request, IFormFile file)
    // {
    //     var s = request;
    //     return Ok();
    // }

    // [HttpPost("PostAsBody")]
    // [Consumes("multipart/form-data")]
    // public async Task<IActionResult> PostAsBody([FromBody] MyRequest request, [FromForm]IFormFile file)
    // {
    //     var s = request;
    //     return Ok();
    // }

    [HttpPost("PostAsModelBinder")]
    public async Task<IActionResult> PostAsModelBinder([ModelBinder(typeof(MyCustomModelBinder))] MyRequest request)
    {
        var s = request;
        return Ok();
    }
}
