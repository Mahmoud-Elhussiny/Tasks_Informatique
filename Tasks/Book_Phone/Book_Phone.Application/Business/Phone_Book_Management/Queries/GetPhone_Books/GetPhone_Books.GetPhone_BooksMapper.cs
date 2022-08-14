using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books
{
    public class GetPhone_Bokks_Mapper : Profile
    {
        public GetPhone_Bokks_Mapper()
        {
            CreateMap<Phones_Book, GetPhone_BooksOutput>()
                .ForMember(dest => dest.phone, opt =>
                opt.MapFrom(src => src.Phone_Numbers[0].Number.ToString()));
                
        }
    }
}
