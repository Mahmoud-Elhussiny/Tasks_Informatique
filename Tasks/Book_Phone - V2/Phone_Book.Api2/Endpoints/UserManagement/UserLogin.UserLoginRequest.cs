using MediatR;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class UserLoginRequest : BaseRequest,IRequest<UserLoginResponse>
    {
        public const string Route = "/API/user/UserManagement/UserLogin/";
        //public const string Route = "/API/user/v{version:apiVersion}/UserManagement/UserLogin/";
        /// <summary>
        /// Student National Number
        /// </summary>
        /// <example>Hussein123</example>
        public string username { get; set; }

        /// <summary>
        /// Student National Number
        /// </summary>
        /// <example>987654321</example>
        public string password { get; set; }
    }
}
