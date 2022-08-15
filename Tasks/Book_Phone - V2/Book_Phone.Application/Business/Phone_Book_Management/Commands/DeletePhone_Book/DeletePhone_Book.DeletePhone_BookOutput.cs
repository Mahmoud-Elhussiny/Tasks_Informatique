using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book
{
    public class DeletePhone_BookOutput:BaseResponse
    {
        public DeletePhone_BookOutput() { }
        public DeletePhone_BookOutput(Guid CorrelationId) : base(CorrelationId) { }
    }
}
