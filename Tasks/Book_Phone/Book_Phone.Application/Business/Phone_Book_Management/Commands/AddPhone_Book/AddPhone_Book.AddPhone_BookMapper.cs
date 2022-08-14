using AutoMapper;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book
{
    internal class AddPhone_Book_Mapper : Profile
    {
        public AddPhone_Book_Mapper()
        {
            CreateMap<AddPhone_BookInput, Phones_Book>()
                .ForMember(dest=>dest.User,opt=>opt.Ignore())
                .ForMember(dest => dest.Phone_Numbers, opt => opt.Ignore());
        }
    }
}
