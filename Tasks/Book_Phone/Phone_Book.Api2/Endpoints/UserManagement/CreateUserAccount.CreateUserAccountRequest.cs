using Phone_Book.Application.Masseges;
using System.ComponentModel.DataAnnotations;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class CreateUserAccountRequest:BaseRequest
    {

        public const string Route = "/API/user/UserManagement/CreateUser/";
        /// <summary>
        /// FirstName
        /// </summary>
        /// <example>Mahmoud</example>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        /// <example>Hussein</example>
        public string LastName { get; set; }

        /// <summary>
        /// Student National Number
        /// </summary>
        /// <example>Hussein123</example>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Student National Number
        /// </summary>
        /// <example>987654321</example>
        [Required]
        public string Password { get; set; }
    }
}
