using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phone_Book.Application.Auth.JWT_Auth;
using Phone_Book.Application.Auth.User;
using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.UserManagement.Commands.UserLogin
{
    public class UserLogin : IRequestHandler<UserLoginInput, UserLoginOutput>
    {
        private IUserRepository _userRepository;
        private JWT _jwt;

        public UserLogin(IUserRepository userRepository, IOptions<JWT> jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt.Value;
        }
        public async Task<UserLoginOutput> Handle(UserLoginInput request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.username))
            {
                throw new Exception("Not Accepted User Name");
            }

            if (string.IsNullOrEmpty(request.password))
            {
                throw new Exception("Not Accepted password");
            }

            var user = await _userRepository.GetAsync(request.username, request.password);
            
            if (user == null)
                throw new Exception("User is not found");

            var jwtSecurityToken = await CreateJwtToken(user);

            var activContext = new ActiveContext
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                expireson = jwtSecurityToken.ValidTo,
                IsAuthnticated = true,
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                username = user.UserName
            };

            UserLoginOutput output = new UserLoginOutput();

            output.activeContext = activContext;

            return output;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {

            var roleClaims = new List<Claim>();


            var claims = new[]
            {
                new Claim(JWTClaims.Id, user.Id.ToString()),
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

            return jwtSecurityToken;
        }


    }
}
