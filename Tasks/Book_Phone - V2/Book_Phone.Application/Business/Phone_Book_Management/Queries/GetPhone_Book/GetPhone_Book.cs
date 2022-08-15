using AutoMapper;
using MediatR;
using Phone_Book.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Book
{
    internal class GetPhone_Book : IRequestHandler<GetPhone_BookInput, GetPhone_BookOutput>
    {
        private IPhone_BookRepository _phone_BookRepository;
        private IMapper _mapper;

        public GetPhone_Book(IPhone_BookRepository phone_BookRepository, IMapper mapper)
        {
            _phone_BookRepository = phone_BookRepository;
            _mapper = mapper;
        }
        public async Task<GetPhone_BookOutput> Handle(GetPhone_BookInput request, CancellationToken cancellationToken)
        {
            
            var Phon_BookDB = await _phone_BookRepository.GetAsync(request.Id,true);

            if (Phon_BookDB == null)
                throw new Exception("This Phone Book Is Not Exist");

            var output = new GetPhone_BookOutput();

            List<string> numbers = new List<string>();

            foreach (var num in Phon_BookDB.Phone_Numbers)
            {
                numbers.Add(num.Number.ToString());
            }
            output = _mapper.Map<GetPhone_BookOutput>(Phon_BookDB);
            output.Phones = numbers;
            return output;
        }
    }
}
