using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book
{
    public class AddPhone_BookOutput:BaseRequest
    {
        public AddPhone_BookOutput() { }
        public AddPhone_BookOutput(Guid CorrelationId) : base(CorrelationId) { }
        public Guid Id { get; set; }
    }
}
