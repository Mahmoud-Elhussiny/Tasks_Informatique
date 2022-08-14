using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.UserManagement.Commands.UserLogin
{
    public class UserLoginInput:BaseRequest,IRequest<UserLoginOutput>
    {
        public UserLoginInput() { }
        public UserLoginInput(Guid correlationId) : base(correlationId) { }

        public string username { get; set; }
        public string password { get; set; }


    }
}
