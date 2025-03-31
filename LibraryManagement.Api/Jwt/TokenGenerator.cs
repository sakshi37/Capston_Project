

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibraryManagement.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagement.Api.Jwt
{

    public class TokenGenerator
    {
        public static string GenrateAccessToken(ApplicationUser user)
        {
            var key = Encoding.UTF8.GetBytes("YourSecureKeyHereMustBeAtLeast16Chars");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptive = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {

                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)

                }),

                Expires = DateTime.UtcNow.AddMinutes(155),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptive);
            return tokenHandler.WriteToken(token);


        }
    }
}
