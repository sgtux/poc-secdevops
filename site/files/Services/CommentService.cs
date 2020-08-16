using System.Collections.Generic;
using System.Linq;
using VWAT.Models;
using VWAT.Repositories;

namespace VWAT.Services
{
  public class CommentService
  {
    private CommentRepository _commentRepository;

    public CommentService(CommentRepository commentRepository)
    {
      _commentRepository = commentRepository;
    }

    public void Add(string description)
    {
      if (!string.IsNullOrEmpty(description))
      {
        _commentRepository.Add(new CommentModel()
        {
          Description = description,
          Date = System.DateTime.Now
        });
      }
    }

    public IEnumerable<CommentModel> GetAll() => _commentRepository.GetAll();

    public void Remove(long id) => _commentRepository.Remove(id);
  }
}