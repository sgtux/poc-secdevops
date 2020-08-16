// using System;
// using System.iden

// namespace VWAT.Auth
// {
//   public sealed class JwtToken
//   {
//     private JwtSecurityToken token;
//     public JwtToken(JwtSecurityToken token)
//     {
//       this.token = token;
//     }

//     public DateTime ValidTo => token.ValidTo;

//     public string Value => new JwtSecurityTokenHandler().WriteToken(token);
//   }
// }