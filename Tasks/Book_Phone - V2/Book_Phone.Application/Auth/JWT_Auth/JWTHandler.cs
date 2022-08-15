using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Auth.JWT_Auth
{
    public class JWTHandler
    {
        
        public static async Task<JwtSecurityToken> CreateJwtToken(User user,JWT _jwt)
        {
            
            var roleClaims = new List<Claim>();
            

            var claims = new[]
            {
                new Claim(JWTClaims.Id,user.Id.ToString()),
                new Claim(JWTClaims.UserName, user.UserName),
                new Claim(JWTClaims.FirstName, user.FirstName),
                new Claim(JWTClaims.LastName, user.LastName),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return await Task.FromResult(jwtSecurityToken);
        }
    }
}
