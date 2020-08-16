using VWAT.Config;
using VWAT.Models;
using System.Collections.Generic;

namespace VWAT.Repositories
{
  public class UserRepository : BaseRepository<UserModel>
  {
    private const string SELECT_COLUMNS = "\"Id\", \"Name\", \"Email\", \"Password\"";

    public UserRepository(AppConfig config) : base(config) { }

    public long Add(UserModel user)
    {
      var query = $"INSERT INTO \"{TableName}\" (Name, Email, Password) VALUES (@Name, @Email, @Password)";
      Execute(query, user);
      return CurrentId(user);
    }

    public long Update(UserModel user)
    {
      var query = $"UPDATE \"{TableName}\" SET \"Name\" = @Name, \"Email\" = @Email, \"Password\" = @Password, \"Document\" = @Document WHERE Id = @Id";
      Execute(query, user);
      return CurrentId(user);
    }

    public UserModel FindByEmail(string email) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE \"Email\" = '{email}'");

    public UserModel GetById(long id) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE Id = @Id", new { Id = id });

    public IEnumerable<UserModel> GetAll() => Query($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\"");
  }
}