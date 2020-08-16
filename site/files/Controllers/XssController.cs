using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VWAT.Services;

namespace VWAT.Controllers
{
  public class XssController : Controller
  {
    private CommentService _service;

    public XssController(CommentService service)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult XssReflected()
    {
      var list = _service.GetAll();
      return View(list);
    }

    [HttpPost]
    public IActionResult FilterComments(string search)
    {
      ViewBag.Filter = search;
      var list = _service.GetAll();
      if (!string.IsNullOrEmpty(search))
        list = list.Where(p => p.Description.Contains(search));
      return View("XssReflected", list);
    }

    [HttpGet]
    public IActionResult XssStorage()
    {
      ViewBag.Comments = _service.GetAll();
      return View();
    }

    [HttpPost]
    public IActionResult SaveStorage(string comment)
    {
      _service.Add(comment);
      ViewBag.Comments = _service.GetAll();
      return View("XssStorage");
    }

    public IActionResult Delete(int id)
    {
      if (id == 0)
        return NotFound();

      _service.Remove(id);
      ViewBag.Comments = _service.GetAll();
      return View("XssStorage");
    }
  }
}