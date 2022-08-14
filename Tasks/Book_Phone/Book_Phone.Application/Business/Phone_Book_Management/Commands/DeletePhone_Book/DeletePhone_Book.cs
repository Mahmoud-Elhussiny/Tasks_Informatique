using AutoMapper;
using MediatR;
using Phone_Book.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book
{
    internal class DeletePhone_Book : IRequestHandler<DeletePhone_BookInput, DeletePhone_BookOutput>
    {
        private IMapper _mapper;
        private IPhone_BookRepository _phone_BookRepository;

        public DeletePhone_Book(IMapper mapper, IPhone_BookRepository phone_BookRepository)
        {
            _mapper = mapper;
            _phone_BookRepository = phone_BookRepository;

        }
        public async Task<DeletePhone_BookOutput> Handle(DeletePhone_BookInput request, CancellationToken cancellationToken)
        {
            var Phone_BookDb = await _phone_BookRepository.GetAsync(request.Id);
            if (Phone_BookDb == null)
                throw new Exception("Phone_Book Is Not Found");

            await _phone_BookRepository.DeleteAsync(Phone_BookDb);

            var output = new DeletePhone_BookOutput();
            return output;
        }
    }
}
