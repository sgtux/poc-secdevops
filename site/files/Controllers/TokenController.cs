using Microsoft.AspNetCore.Mvc;
using VWAT.Models;
using VWAT.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VWAT.Config;

namespace VWAT.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    private UserService userService;
    private AppConfig appConfig;

    public TokenController(UserService userService, AppConfig appConfig)
    {
      this.userService = userService;
      this.appConfig = appConfig;
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserModel user)
    {
      UserModel login = null;
      if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password))
        login = userService.Login(user.Name, user.Password);
      if (login is null)
        return Unauthorized();

      var tokenHandler = new JwtSecurityTokenHandler();

      var key = Encoding.ASCII.GetBytes(appConfig.JwtKey);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = System.DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
      return Ok(new { Token = token, User = login });
    }
  }
}