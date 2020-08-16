using System.Linq;
using VWAT.Models;
using VWAT.Repositories;

namespace VWAT.Services
{
  public class UserService
  {
    private UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public UserModel Login(string email, string password)
    {
      var user = _userRepository.FindByEmail(email);
      return user?.Password == password ? user.WithoutPassword() : null;
    }
  }
}