using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book
{
    public class UpdatePhone_BookInput :BaseRequest, IRequest<UpdatePhone_BookOutput>
    {
        public UpdatePhone_BookInput() { }
        public UpdatePhone_BookInput(Guid CorrelationId) : base(CorrelationId) { }
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
    
        public List<string> Phone_Numbers { get; set; }
    }
}
