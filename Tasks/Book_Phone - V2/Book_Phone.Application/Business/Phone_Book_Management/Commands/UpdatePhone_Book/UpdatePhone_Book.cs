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

namespace Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book
{
    public class UpdatePhone_Book : IRequestHandler<UpdatePhone_BookInput, UpdatePhone_BookOutput>
    {
        private IMapper _mapper;
        private IPhone_BookRepository _phone_BookRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IPhone_NumberRepository _phone_NumberRepository;

        public UpdatePhone_Book(IMapper mapper,IPhone_BookRepository phone_BookRepository
            ,IHttpContextAccessor httpContextAccessor,IPhone_NumberRepository phone_NumberRepository)
        {
            _mapper = mapper;
            _phone_BookRepository = phone_BookRepository;
            _httpContextAccessor = httpContextAccessor;
            _phone_NumberRepository = phone_NumberRepository;
        }

        public async Task<UpdatePhone_BookOutput> Handle(UpdatePhone_BookInput request, CancellationToken cancellationToken)
        {
            Phones_Book checkPnone_Book = await _phone_BookRepository.GetAsync(request.Id);

            if (checkPnone_Book == null)
                throw new Exception("This Id is not exist");

            List<Claim> claims = _httpContextAccessor.HttpContext!.User.Claims.ToList();
            checkPnone_Book.UserId = Guid.Parse(claims[0].Value);

            checkPnone_Book.Address = request.Address;
            checkPnone_Book.Name = request.Name;
            checkPnone_Book.Id = request.Id;

            if(request.Phone_Numbers.Count>0)
            {
                IEnumerable<Phone_Number> phone_Numbers = await _phone_NumberRepository.GetAllAsync(request.Id);
                foreach(Phone_Number phoneNumber in phone_Numbers)
                    await _phone_NumberRepository.DeleteAsync(phoneNumber);

                foreach(string phone_Number in request.Phone_Numbers)
                {
                    Phone_Number newphoneNumber = new Phone_Number();
                    newphoneNumber.Number = phone_Number;
                    newphoneNumber.Phones_BookId = checkPnone_Book.Id;
                    await _phone_NumberRepository.AddAsync(newphoneNumber);
                }

            }

            await _phone_BookRepository.SaveChangeAsync();
            
            var output = new UpdatePhone_BookOutput();
            return output;
        }
    }
}
