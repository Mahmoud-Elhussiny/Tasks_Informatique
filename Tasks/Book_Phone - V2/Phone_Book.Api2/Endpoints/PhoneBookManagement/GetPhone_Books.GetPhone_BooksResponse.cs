using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BooksResponse:BaseResponse
    {
        public GetPhone_BooksResponse()
        {

        }
        public GetPhone_BooksResponse(Guid correlationId) : base(correlationId) { }


        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
    }
}
