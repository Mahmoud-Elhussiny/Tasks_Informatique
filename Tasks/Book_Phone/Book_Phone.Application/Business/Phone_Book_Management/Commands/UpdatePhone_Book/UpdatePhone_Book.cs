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

        public UpdatePhone_Book(IMapper mapper,IPhone_BookRepository phone_BookRepository
            ,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _phone_BookRepository = phone_BookRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdatePhone_BookOutput> Handle(UpdatePhone_BookInput request, CancellationToken cancellationToken)
        {
            Phones_Book checkPnone_Book = await _phone_BookRepository.GetAsync(request.Id);

            if (checkPnone_Book == null)
                throw new Exception("This Id is not exist");

            //Phones_Book phone_BookDb = new Phones_Book();
            List<Claim> claims = _httpContextAccessor.HttpContext!.User.Claims.ToList();
            checkPnone_Book.UserId = Guid.Parse(claims[0].Value);

            checkPnone_Book.Address = request.Address;
            checkPnone_Book.Name = request.Name;
            checkPnone_Book.Id = request.Id;


            //var Phone_BookDB = _mapper.Map<Phones_Book>(request);
            //await _phone_BookRepository.UpdateAsync(phone_BookDb);
            await _phone_BookRepository.SaveChangeAsync();
            
            var output = new UpdatePhone_BookOutput();
            return output;
        }
    }
}
