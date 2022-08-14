using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class UpdatePhone_BookMapper:Profile
    {
        public UpdatePhone_BookMapper()
        {
            CreateMap<UpdatePhone_BookRequest, UpdatePhone_BookInput>()
             .ConstructUsing(src => new UpdatePhone_BookInput(src.CorrelationId()));

            CreateMap<UpdatePhone_BookOutput, UpdatePhone_BookResponse>()
                .ConstructUsing(src => new UpdatePhone_BookResponse(src.CorrelationId()));
        }
    }
}
