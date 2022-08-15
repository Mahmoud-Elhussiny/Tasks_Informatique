using Phone_Book.Application.Masseges;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class AddPhone_BookResponse:BaseResponse
    {
        public AddPhone_BookResponse() { }
        public AddPhone_BookResponse(Guid CorrelationId) : base(CorrelationId) { }
       
        public Guid Id { get; set; }

    }
}
