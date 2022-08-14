using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class DeletePhone_BookResponse:BaseResponse
    {
        public DeletePhone_BookResponse() { }
        public DeletePhone_BookResponse(Guid CorrelationId) : base(CorrelationId) { }
    }
}
