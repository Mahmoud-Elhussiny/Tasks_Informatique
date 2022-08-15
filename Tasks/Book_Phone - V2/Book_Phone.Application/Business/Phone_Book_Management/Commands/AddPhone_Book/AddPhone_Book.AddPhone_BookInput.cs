using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book
{
    public class AddPhone_BookInput : BaseRequest,IRequest<AddPhone_BookOutput>
    {
        public AddPhone_BookInput() { }
        public AddPhone_BookInput(Guid CorrelationId) : base(CorrelationId) { }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public List<string> Phone_Numbers { get; set; }

    }
}
