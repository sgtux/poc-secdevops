using VWAT.Enums;

namespace VWAT.Models
{
  public class UserModel : BaseEntity
  {
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public UserRole Role { get; set; }

    public string Document { get; set; }

    public UserModel WithoutPassword() => new UserModel { Id = Id, Name = Name, Email = Email, Role = Role, Document = Document };

    public override string EntityName => "User";
  }
}