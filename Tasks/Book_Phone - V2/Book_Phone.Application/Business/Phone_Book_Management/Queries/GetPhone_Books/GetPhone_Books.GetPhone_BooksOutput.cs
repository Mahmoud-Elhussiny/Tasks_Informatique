using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books
{
    public class GetPhone_BooksOutput:BaseResponse
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
    }
}
