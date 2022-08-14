using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book
{
    public class GetPhone_BookInput : BaseRequest,IRequest<GetPhone_BookOutput>
    {
        public GetPhone_BookInput(){}

        public GetPhone_BookInput(Guid correlationId) : base(correlationId) {}

        public Guid Id { get; set; }
    }
}
