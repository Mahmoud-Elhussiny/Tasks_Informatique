using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class AddPhone_BookMapper:Profile
    {
        public AddPhone_BookMapper()
        {
            CreateMap<AddPhone_BookRequest, AddPhone_BookInput>()
             .ConstructUsing(src => new AddPhone_BookInput(src.CorrelationId()));

            CreateMap<AddPhone_BookOutput, AddPhone_BookResponse>()
                .ConstructUsing(src => new AddPhone_BookResponse(src.CorrelationId()));
        }
    }
}
