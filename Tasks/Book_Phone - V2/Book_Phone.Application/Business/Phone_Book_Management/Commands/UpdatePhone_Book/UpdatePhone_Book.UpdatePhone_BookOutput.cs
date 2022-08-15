using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book
{
    public class UpdatePhone_BookOutput:BaseResponse
    {
        public UpdatePhone_BookOutput() { }
        public UpdatePhone_BookOutput(Guid CorrelationId) : base(CorrelationId) { }
    }
}
