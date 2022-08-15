using MediatR;
using Phone_Book.Application.Masseges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books
{
    public class GetPhone_BooksInput :BaseRequest ,IRequest<List<GetPhone_BooksOutput>>
    {
        public GetPhone_BooksInput(){ }


        public GetPhone_BooksInput(Guid correlationId) : base(correlationId) { }
        
    }
}
