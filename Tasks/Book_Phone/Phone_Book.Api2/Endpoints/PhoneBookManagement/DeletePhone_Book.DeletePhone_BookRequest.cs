using MediatR;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class DeletePhone_BookRequest: BaseRequest,IRequest<DeletePhone_BookResponse>
    {
        public const string Route = "/Api/Phone_Books/delete/{Id}";
        public Guid Id { get; set; }
    }
   
}
