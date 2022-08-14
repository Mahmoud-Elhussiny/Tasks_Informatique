using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BookMapper:Profile
    {
        public GetPhone_BookMapper()
        {
            CreateMap<GetPhone_BookRequest, GetPhone_BookInput>()
              .ConstructUsing(src => new GetPhone_BookInput(src.CorrelationId()));

            CreateMap<GetPhone_BookOutput, GetPhone_BookResponse>()
                .ConstructUsing(src => new GetPhone_BookResponse(src.CorrelationId()));
        }
    }
}
