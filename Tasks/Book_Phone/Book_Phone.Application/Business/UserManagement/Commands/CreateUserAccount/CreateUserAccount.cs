using AutoMapper;
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

namespace Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount
{
    public class CreateUserAccount : IRequestHandler<CreateUserAccountInput, CreateUserAccountOutput>
    {
        IUserRepository _userRepository;
        private IMapper _mapper;
        private JWT _jwt;

        public CreateUserAccount(IMapper mapper,IUserRepository userRepository, IOptions<JWT> jwt)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwt = jwt.Value;

        }
        public async Task<CreateUserAccountOutput> Handle(CreateUserAccountInput request, CancellationToken cancellationToken)
        {
            var output = new CreateUserAccountOutput();
            var testusername = await _userRepository.CheckUserName(request.Username);
           
            if (testusername is not null)
            {
                output.activeContext.message = "user name is existed";
                return output;
            }

            User userDb = new User();
            userDb.Id = Guid.NewGuid();
            
            userDb = _mapper.Map(request,userDb);
            
            var userereturn = await _userRepository.AddAsync(userDb);
            await _userRepository.SaveChangeAsync();
            
            var jwtSecurityToken = await CreateJwtToken(userDb);

            var activContext = new ActiveContext
            {
                Id = userDb.Id,
                FirstName = userDb.FirstName,
                LastName = userDb.LastName,
                expireson = jwtSecurityToken.ValidTo,
                IsAuthnticated = true,
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                username = userDb.UserName
            };

            output.activeContext = activContext;

            return output;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
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

            return jwtSecurityToken;
        }




    }
}
