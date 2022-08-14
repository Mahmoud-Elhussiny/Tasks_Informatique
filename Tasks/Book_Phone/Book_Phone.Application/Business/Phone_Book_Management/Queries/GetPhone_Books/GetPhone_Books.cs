using AutoMapper;
using MediatR;
using Phone_Book.Application.Auth.JWT_Auth;
using Phone_Book.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books
{
    public class GetPhone_Books
        : IRequestHandler<GetPhone_BooksInput, List<GetPhone_BooksOutput>>
    {
        private IPhone_BookRepository _phone_BookRepository;
        private IMapper _mapper;
       
        public GetPhone_Books(IPhone_BookRepository phone_BookRepository, IMapper mapper)
        {
            _phone_BookRepository = phone_BookRepository;
            _mapper = mapper;
         
        }


        public async Task<List<GetPhone_BooksOutput>> Handle(GetPhone_BooksInput request, CancellationToken cancellationToken)
        {
            
            var PhoneBookDB = await _phone_BookRepository.GetAllAsync(true);

            var Output = _mapper.Map<List<GetPhone_BooksOutput>>(PhoneBookDB);

            return Output;
        }

    }
}
