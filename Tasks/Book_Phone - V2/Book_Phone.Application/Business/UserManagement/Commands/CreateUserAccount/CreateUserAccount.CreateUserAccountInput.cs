using Phone_Book.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount
{
    public class CreateUserAccountInput :BaseRequest ,IRequest<CreateUserAccountOutput>
    {
        public CreateUserAccountInput(){ }
        public CreateUserAccountInput(Guid correlationId):base(correlationId){ }
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
