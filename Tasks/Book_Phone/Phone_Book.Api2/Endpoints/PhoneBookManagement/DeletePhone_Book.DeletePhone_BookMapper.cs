using AutoMapper;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class DeletePhone_BookMapper:Profile
    {
        public DeletePhone_BookMapper()
        {
            CreateMap<DeletePhone_BookRequest, DeletePhone_BookInput>()
             .ConstructUsing(src => new DeletePhone_BookInput(src.CorrelationId()));

            CreateMap<DeletePhone_BookOutput, DeletePhone_BookResponse>()
                .ConstructUsing(src => new DeletePhone_BookResponse(src.CorrelationId()));
        }
    }
}
