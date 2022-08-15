using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book
{
    public class DeletePhone_BookInput :BaseRequest,IRequest<DeletePhone_BookOutput>
    {

        public DeletePhone_BookInput() { }
        public DeletePhone_BookInput(Guid CorrelationId) : base(CorrelationId) { }
        public Guid Id { get; set; }
    }
}
