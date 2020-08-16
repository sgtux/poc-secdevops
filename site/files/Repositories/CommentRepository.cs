using VWAT.Config;
using VWAT.Models;
using System.Collections.Generic;

namespace VWAT.Repositories
{
  public class CommentRepository : BaseRepository<CommentModel>
  {
    private const string SELECT_COLUMNS = "\"Id\", \"Description\", \"Date\"";

    public CommentRepository(AppConfig config) : base(config) { }

    public long Add(CommentModel user)
    {
      var query = $"INSERT INTO \"{TableName}\" (\"Description\", \"Date\") VALUES (@Description, @Date)";
      Execute(query, user);
      return CurrentId(user);
    }

    public IEnumerable<CommentModel> GetAll() => Query($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\"");
  }
}