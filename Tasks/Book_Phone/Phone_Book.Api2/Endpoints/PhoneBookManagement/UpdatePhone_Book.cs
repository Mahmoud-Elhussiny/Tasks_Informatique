using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Api2.Attributes;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.UpdatePhone_Book;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class UpdatePhone_Book : EndpointBaseAsync
        .WithRequest<UpdatePhone_BookRequest>
        .WithActionResult<UpdatePhone_BookResponse>
    {
        private readonly ILogger<GetPhone_Book> _logger;
        private IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdatePhone_Book(ILogger<GetPhone_Book> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("1.0")]
        [HttpPut(UpdatePhone_BookRequest.Route)]
        [SwaggerOperation(Summary = "Delete Phone Book", Description = "Delete Phone Book")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(DeletePhone_BookResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]

        public override async Task<ActionResult<UpdatePhone_BookResponse>> HandleAsync(UpdatePhone_BookRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<UpdatePhone_BookInput>(request);
            var result = await _mediator.Send(input, cancellationToken);
            var Response = _mapper.Map<UpdatePhone_BookResponse>(result);

            return Ok(Response);
        }
    }
}
