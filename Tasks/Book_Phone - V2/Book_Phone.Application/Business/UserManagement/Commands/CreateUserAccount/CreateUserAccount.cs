using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Phone_Book.Application.Auth.JWT_Auth;
using Phone_Book.Application.Auth.Users;
using Phone_Book.Application.Exceptions;
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
                throw new WebApiException("user name is existed");
                
            }

            User userDb = new User();
            userDb.Id = Guid.NewGuid();
            
            userDb = _mapper.Map(request,userDb);
            
            var userereturn = await _userRepository.AddAsync(userDb);
            await _userRepository.SaveChangeAsync();
            
            var jwtSecurityToken = await JWTHandler.CreateJwtToken(userDb,_jwt);
            
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

    }
}
