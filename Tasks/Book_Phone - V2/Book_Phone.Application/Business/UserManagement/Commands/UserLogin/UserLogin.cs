using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phone_Book.Application.Auth.JWT_Auth;
using Phone_Book.Application.Auth.Users;
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

            var jwtSecurityToken = await JWTHandler.CreateJwtToken(user,_jwt);

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


    }
}
