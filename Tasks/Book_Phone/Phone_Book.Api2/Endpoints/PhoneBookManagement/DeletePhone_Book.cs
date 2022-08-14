using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Business.Phone_Book_Management.Commands.DeletePhone_Book;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class DeletePhone_Book : EndpointBaseAsync
        .WithRequest<DeletePhone_BookRequest>
        .WithActionResult<DeletePhone_BookResponse>
    {

        private readonly ILogger<GetPhone_Book> _logger;
        private IMapper _mapper;
        private readonly IMediator _mediator;
        public DeletePhone_Book(ILogger<GetPhone_Book> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("1.0")]
        [HttpDelete(DeletePhone_BookRequest.Route)]
        [SwaggerOperation(Summary = "Get Phone Book Details", Description = "Get Phone Book Details")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(DeletePhone_BookResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]

        public override async Task<ActionResult<DeletePhone_BookResponse>> HandleAsync([FromRoute]DeletePhone_BookRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<DeletePhone_BookInput>(request);
            var result = await _mediator.Send(input, cancellationToken);
            var Response = _mapper.Map<DeletePhone_BookResponse>(result);

            return Ok(Response);
        }
    }
}
