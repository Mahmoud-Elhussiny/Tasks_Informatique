using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Masseges;
using System.ComponentModel.DataAnnotations;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    [BindProperties(SupportsGet = true)]
    public class UpdatePhone_BookRequest:BaseRequest,IRequest<UpdatePhone_BookResponse>
    {
        public const string Route = "/Api/Phone_Books/Update/{Id}";

        [FromRoute]
        [Required]
        public Guid Id { get; set; }



        [FromBody]
        public string Name { get; set; }
        
        [FromBody]
        public string Address { get; set; }
        [FromBody]
        public List<string> Phone_Numbers { get; set; }


    }
}
