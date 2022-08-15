using Phone_Book.Application.Masseges;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book
{
    public class GetPhone_BookOutput:BaseResponse
    {
        public GetPhone_BookOutput() {}

        public GetPhone_BookOutput(Guid CorrelationId):base(CorrelationId){}

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public List<string> Phones { get; set; }

    }
}
