using AutoMapper;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book
{
    internal class GetPhone_BookMapper : Profile
    {
        public GetPhone_BookMapper()
        {
            CreateMap<Phones_Book, GetPhone_BookOutput>();
              
        }
    }
}
