using Phone_Book.Application.Auth.Users;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class CreateUserAccountResponse:BaseResponse
    {
        public CreateUserAccountResponse() { }
        public CreateUserAccountResponse(Guid correlationId) : base(correlationId) { }

        public ActiveContext activeContext { get; set; }
    }
}
