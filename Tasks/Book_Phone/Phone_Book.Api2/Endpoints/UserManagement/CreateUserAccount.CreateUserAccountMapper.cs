using AutoMapper;
using Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class CreateUserAccountMapper:Profile
    {
        public CreateUserAccountMapper()
        {
            CreateMap<CreateUserAccountRequest, CreateUserAccountInput>()
                 .ConstructUsing(src => new CreateUserAccountInput(src.CorrelationId()));

            CreateMap<CreateUserAccountOutput, CreateUserAccountResponse>()
                .ConstructUsing(src => new CreateUserAccountResponse(src.CorrelationId()));
        }
    }
}
