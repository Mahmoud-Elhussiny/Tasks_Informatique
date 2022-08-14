using AutoMapper;
using Phone_Book.Application.Business.UserManagement.Commands.UserLogin;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class UserLoginMapprer:Profile
    {
        public UserLoginMapprer()
        {
            CreateMap<UserLoginRequest, UserLoginInput>()
                .ConstructUsing(src => new UserLoginInput(src.CorrelationId()));

            CreateMap<UserLoginOutput, UserLoginResponse>()
                .ConstructUsing(src => new UserLoginResponse(src.CorrelationId()));
        }
    }
}
