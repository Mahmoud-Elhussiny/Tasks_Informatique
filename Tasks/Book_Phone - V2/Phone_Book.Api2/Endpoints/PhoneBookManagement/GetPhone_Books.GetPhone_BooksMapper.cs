using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BooksMapper:Profile
    {
        public GetPhone_BooksMapper()
        {
            CreateMap<GetPhone_BooksRequest,GetPhone_BooksInput>()
                .ConstructUsing(src=> new GetPhone_BooksInput(src.CorrelationId()));

            CreateMap<GetPhone_BooksOutput, GetPhone_BooksResponse>()
                .ConstructUsing(src => new GetPhone_BooksResponse(src.CorrelationId()));

        }
    }
}
