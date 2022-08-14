using MediatR;
using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BooksRequest:BaseRequest,IRequest<GetPhone_BooksResponse>
    {
        public const string Route = "/Api/Phone_Books/GetAll";


    }
}
