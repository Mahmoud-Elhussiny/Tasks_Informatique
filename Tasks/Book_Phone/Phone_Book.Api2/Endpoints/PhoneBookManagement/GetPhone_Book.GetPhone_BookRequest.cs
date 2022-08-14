using MediatR;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BookRequest:BaseRequest,IRequest<GetPhone_BookResponse>
    {
        public const string Route = "/Api/Phone_Books/{Id}";
        public Guid Id { get; set; }
    }
}
