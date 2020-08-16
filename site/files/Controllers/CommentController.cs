using Microsoft.AspNetCore.Mvc;
using VWAT.Models;
using VWAT.Services;

namespace VWAT.Controllers
{
  [Route("api/[controller]")]
  public class CommentController : Controller
  {
    private CommentService _service;
    public CommentController(CommentService service) => _service = service;

    [HttpPost]
    public IActionResult Post([FromBody] CommentModel comment)
    {
      if (!string.IsNullOrEmpty(comment?.Description))
      {
        _service.Add(comment.Description);
        return Ok();
      }
      else
        return UnprocessableEntity("Invalid request");
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetAll());

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _service.Remove(id);
      return Ok();
    }
  }
}