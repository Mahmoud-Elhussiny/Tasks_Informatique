using MediatR;
using Phone_Book.Application.Masseges;
using System.ComponentModel.DataAnnotations;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class AddPhone_BookRequest:BaseRequest,IRequest<AddPhone_BookResponse>
    {
        public const string Route = "/Api/Phone_Books/Add";
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public List<string> Phone_Numbers { get; set; }
    }
}
