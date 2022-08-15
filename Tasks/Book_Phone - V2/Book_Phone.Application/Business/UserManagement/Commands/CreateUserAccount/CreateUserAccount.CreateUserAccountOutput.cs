using Phone_Book.Application.Auth.Users;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount
{
    public class CreateUserAccountOutput:BaseResponse
    {
        public CreateUserAccountOutput() { }
        public CreateUserAccountOutput(Guid correlationId) : base(correlationId) { }
        public ActiveContext activeContext { get; set; }
        
    }
}
