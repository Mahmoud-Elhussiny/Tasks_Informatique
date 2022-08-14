using Phone_Book.Application.Masseges;
using Phone_Book.Domain;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_BookResponse:BaseResponse
    {
        public GetPhone_BookResponse(){}
        public GetPhone_BookResponse(Guid CorrelationId):base(CorrelationId){ }

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public List<string> Phones { get; set; }

    }
}
