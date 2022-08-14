using AutoMapper;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book
{
    public class UpdatePhone_Book_Mapper : Profile
    {
        public UpdatePhone_Book_Mapper()
        {
            CreateMap<UpdatePhone_BookInput, Phones_Book>();
        }
    }
}
