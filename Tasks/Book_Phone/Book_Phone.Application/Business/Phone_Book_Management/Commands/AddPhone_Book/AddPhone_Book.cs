using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book
{
    public class AddPhone_Book : IRequestHandler<AddPhone_BookInput, AddPhone_BookOutput>
    {
        private IMapper _mapper;
        private IPhone_BookRepository _phone_BookRepository;
        private IPhone_NumberRepository _phone_NumberRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AddPhone_Book(IMapper mapper, IPhone_BookRepository phone_BookRepository
            , IPhone_NumberRepository phone_NumberRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _phone_BookRepository = phone_BookRepository;
            _phone_NumberRepository = phone_NumberRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<AddPhone_BookOutput> Handle(AddPhone_BookInput request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            Phones_Book phone_BookDb = new Phones_Book();

            Phone_Number phone_Numbers = new Phone_Number();

            phone_BookDb.Id = Guid.NewGuid();

            List<Claim> claims = _httpContextAccessor.HttpContext!.User.Claims.ToList();
            phone_BookDb.UserId = Guid.Parse(claims[0].Value);

            phone_BookDb = _mapper.Map(request, phone_BookDb);
            var phone_Book_return = await _phone_BookRepository.AddAsync(phone_BookDb);
            await _phone_BookRepository.SaveChangeAsync();


            foreach(var nums in request.Phone_Numbers)
            {
                phone_Numbers.Id = Guid.NewGuid();
                phone_Numbers.Phones_BookId = phone_BookDb.Id;
                phone_Numbers.Number = nums;
                var res = await _phone_NumberRepository.AddAsync(phone_Numbers);

                await _phone_NumberRepository.SaveChangeAsync();

            }

            await _phone_BookRepository.SaveChangeAsync();

            if (phone_Book_return == null)
                throw new Exception("Error in Add PhoneBook");

            var output = new AddPhone_BookOutput() { Id = phone_Book_return.Id };
            return output;

        }
    }
}
