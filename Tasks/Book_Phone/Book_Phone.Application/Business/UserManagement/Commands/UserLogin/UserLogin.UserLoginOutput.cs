using Phone_Book.Application.Auth.User;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.UserManagement.Commands.UserLogin
{
    public class UserLoginOutput:BaseResponse
    {
        public UserLoginOutput() { }
        public UserLoginOutput(Guid correlationId) : base(correlationId) { }

        public ActiveContext activeContext { get; set; }

    }
}
