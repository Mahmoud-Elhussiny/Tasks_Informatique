using AutoMapper;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount
{
    public class CreateUserAccountMapper : Profile
    {
        public CreateUserAccountMapper()
        {
            CreateMap<CreateUserAccountInput, User>().ReverseMap();
        }
    }
}
