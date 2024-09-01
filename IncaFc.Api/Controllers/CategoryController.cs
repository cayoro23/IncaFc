using Microsoft.AspNetCore.Mvc;

namespace IncaFc.Api.Controllers;

[Route("[controller]")]
public class CategoryController : ApiController
{
    [HttpGet]
    public IActionResult ListCategory()
    {
        return Ok(Array.Empty<string>());
    }
}