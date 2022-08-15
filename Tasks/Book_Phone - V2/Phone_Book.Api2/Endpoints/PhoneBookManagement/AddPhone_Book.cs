using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.AddPhone_Book;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class AddPhone_Book : EndpointBaseAsync
        .WithRequest<AddPhone_BookRequest>
        .WithActionResult<AddPhone_BookResponse>
    {

        private readonly ILogger<GetPhone_Book> _logger;
        private IMapper _mapper;
        private readonly IMediator _mediator;
        public AddPhone_Book(ILogger<GetPhone_Book> logger, IMediator mediator
            ,IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("1.0")]
        [HttpPost(AddPhone_BookRequest.Route)]
        [SwaggerOperation(Summary = "Get Phone Book Details", Description = "Get Phone Book Details")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddPhone_BookResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]


        public override async Task<ActionResult<AddPhone_BookResponse>> HandleAsync(AddPhone_BookRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<AddPhone_BookInput>(request);
            var result = await _mediator.Send(input, cancellationToken);
            var Response = _mapper.Map<AddPhone_BookResponse>(result);

            return Ok(Response);
        }
    }
}
